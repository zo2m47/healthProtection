using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
* Game play controller
* */

public class GameController : ControllerSingleTone<GameController>
{
    public delegate void DelegateEmpty();
    public DelegateEmpty removeAllGameElementsDelegate;

    private bool _roundPlaying = false;

    private IRoundGameController _roundController;
    private ICoreGameController _coreController;

    private List<string> _selectedAntiBodiesId = new List<string>();
    public List<string> selectedAntiBodiesId { get { return _selectedAntiBodiesId; } }
    private RoundVO _roundData;

    public void SetRoundData(string roundId, List<string> l_selectedAntiBodiesId) { 
        _selectedAntiBodiesId = l_selectedAntiBodiesId;
        _roundData = StaticDataModel.Instance.GetRoundById(roundId);
        StartRound();
    }
    //reset round from GUI 
    public void ResetRound()
    {
        StartRound();
    }
    //start round play 
    private void StartRound()
    {
        //set deactiv only drag for input controller
        InputController.Instance.justOnlyDragInWorld = false;

        //change bg 
        ParallaxManager.Instance.InitParallaxData(_roundData);
        BackgroundController.Instance.InitRoundBg(_roundData);
        //creat instance of round 
        _roundController = PrefabRoundCreator.CreatRoundGameController(_roundData);
        _roundController.SetData(_roundData);
        //creat instance of core 
        CoreVO coreData = StaticDataModel.Instance.GetCoreById(_roundData.core);
        _coreController = PrefabCoreCreator.CreatCore(coreData);
        _coreController.SetData(coreData);
        
        UIModel.Instance.ShowGUI();
        //
        StartCoroutine(RoundLoading());
    }
    
    private IEnumerator RoundLoading()
    {
        Debug.Log("Start loading");
        //TODO show loading 
        yield return null;
        Debug.Log("Start Round");
        _roundController.StartRound();
        _roundPlaying = true;
    }
    
    /*work with core 
     * */
    //get core position
    public Vector3 corePosition
    {
        get
        {
            return _coreController.corePosition;
        }
    }
    //core call this method when core died
    public void CoreDied()
    {
        UIModel.Instance.ShowPopUp(PopUpNameEnum.gameOver);
        FinishRound();
    }

    /*work with round 
     * */
    //exit from round 
    private void FinishRound()
    {
        if (removeAllGameElementsDelegate != null)
        {
            removeAllGameElementsDelegate();
        }
        _roundPlaying = false;
    }
    
    public void PauseGame()
    {
        _roundPlaying = false;
    }
    public void ContinueGame()
    {
        _roundPlaying = true;
    }
    /* work with Antibodies
     * */
    //input manager tell about touch in display
    public void TouchCordinat(Vector3 touchPosition)
    {
        if (_roundPlaying)
        {
            string antyBodyId = UIModel.Instance.guiController.TryShootAntyBody();
            if (antyBodyId!="")
            {
                CreatAntiBodyPrefab(StaticDataModel.Instance.GetAntiBodyById(antyBodyId), new AttackDirectionVO(touchPosition));
            } else
            {
                //TODO canot creat instance bc cooldow no ready 
                
            }
        }
    }

    //creat prefab
    private void CreatAntiBodyPrefab(AntiBodyVO data, AttackDirectionVO directionData)
    {
        AntiBodyBaseGameController antiBodyBaseGameController = PrefabAntBodyCreator.CreatAntiBody(data, directionData.startPosition);
        antiBodyBaseGameController.SetStaticData(data);
        antiBodyBaseGameController.SetDirection(directionData);
    }
}
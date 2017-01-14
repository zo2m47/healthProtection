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

    private string _selectedAntiBody = "antiBody1";
    //start round play 
    public void StartRound(string roundId)
    {
        //set deactiv only drag for input controller
        InputController.Instance.justOnlyDragInWorld = false;

        RoundVO roundData = StaticDataModel.Instance.GetRoundById(roundId);
        //change bg 
        ParallaxManager.Instance.InitParallaxData(roundData);
        BackgroundController.Instance.InitRoundBg(roundData);

        UIModel.Instance.ShowGUI();
        //creat instance of round 
        _roundController = PrefabRoundCreator.CreatRoundGameController(roundData);
        _roundController.SetData(roundData);
        //creat instance of core 
        CoreVO coreData = StaticDataModel.Instance.GetCoreById(roundData.core);
        _coreController = PrefabCoreCreator.CreatCore(coreData);
        _coreController.SetData(coreData);
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
        Debug.Log("TODO CoreDied");
    }

    /*work with round 
     * */
    //exit from round 
    private void ExitRound()
    {
        if (removeAllGameElementsDelegate != null)
        {
            removeAllGameElementsDelegate();
        }
    }

    public void StopRound()
    {
        _roundPlaying = false;
    }

    /* work with Attack
     * */
     //input manager tell about touch in display
    public void TouchCordinat(Vector3 touchPosition)
    {
        if (_roundPlaying && _selectedAntiBody!="")
        {
            CreatAntiBodyPrefab(StaticDataModel.Instance.GetAntiBodyById(_selectedAntiBody), new AttackDirectionVO(touchPosition));
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
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System;

public class MainMenuController : UIController
{
    /* Buttons
     * */
    [SerializeField]
    private Button _btnPrevious;
    [SerializeField]
    private Button _btnNext;
    [SerializeField]
    private Button _btnPlay;
    /*tf
     * */
    [SerializeField]
    private Text _tfRoundName;
    [SerializeField]
    private Text _tfDescription;
    [SerializeField]
    private Text _tfBodyName;
    /*lists
     * */
    [SerializeField]
    private GameObject _antiBodyPreviewContainer;
    private List<PreviewAntiBodyController> _antiBodyPreviewList = new List<PreviewAntiBodyController>();

    [SerializeField]
    private GameObject _antiBodySelectedContainer;
    private List<SelectedAntiBodyController> _antiBodySelectedList = new List<SelectedAntiBodyController>();
    private List<String> _antiBodySelectedId = new List<string>();

    [SerializeField]
    private GameObject _virusesPreviewContainer;
    private List<PreviewVirusController> _virusesPreviewList = new List<PreviewVirusController>();

    private int _bodyIndex = 0;
    
    private List<BodyVO> _bodyList = new List<BodyVO>();
    private BodyViewController _bodyViewController;

    private string _selectedRoundId;

    protected override void GameObjectActivate()
    {
        CheckOnAllUIComponents();
        base.GameObjectActivate();
    }
    
    public override UINamesEnum uiName
    {
        get
        {
            return UINamesEnum.mainMenu;
        }
    }

    protected override void CheckOnAllUIComponents()
    {
        if (_btnNext == null)
        {
            LoggingManager.AddErrorToLog("_btnNext doesnt exist");
        }
        if (_btnPrevious == null)
        {
            LoggingManager.AddErrorToLog("_btnPrevious doesnt exist");
        }
        if (_btnPlay == null)
        {
            LoggingManager.AddErrorToLog("_btnPlay doesnt exist");
        }
        if (_tfRoundName == null)
        {
            LoggingManager.AddErrorToLog("_tfRoundName doesnt exist");
        }
        if (_tfDescription == null)
        {
            LoggingManager.AddErrorToLog("_tfDescription doesnt exist");
        }
        if (_tfBodyName == null)
        {
            LoggingManager.AddErrorToLog("_tfBodyName doesnt exist");
        }
        if (_antiBodyPreviewContainer == null)
        {
            LoggingManager.AddErrorToLog("_antiBodyPreviewContainer doesnt exist");
        }
        if (_antiBodySelectedContainer == null)
        {
            LoggingManager.AddErrorToLog("_antiBodySelectedContainer doesnt exist");
        }
        if (_virusesPreviewContainer == null)
        {
            LoggingManager.AddErrorToLog("_VirusesPreviewContainer doesnt exist");
        }
    }
    protected override void SetDefaultSetting()
    {
        _bodyIndex = 0;
        _selectedRoundId = "";
        //delete parallax 
        ParallaxManager.Instance.ResetAllParallax();

        if (_bodyList.Count == 0)
        {
            _bodyList = StaticDataModel.Instance.bodiesList;
            //sort list by listSort
            _bodyList.Sort(delegate (BodyVO a, BodyVO b)
            {
                return (a.listSort).CompareTo(b.listSort);
            });
        }
        //parallax 
        ParallaxManager.Instance.ResetAllParallax();
        //preview lists 
        ShowUserAntiBodies();
        //los selected settings
        PrepareUserSelectedAntiBodiesSlots();

        ShoweBodyInformation();
    }

    public override void Activate()
    {
        base.Activate();
        SetDefaultSetting();
    }
    /* Buttons actions
     * */
    public void PreviousBtnClicked()
    {
        _bodyIndex--;
        ShoweBodyInformation();
    }

    public void NextBtnClicked()
    {
        _bodyIndex++;
        ShoweBodyInformation();
    }

    public void PlayBtnClicked()
    {
        if (_selectedRoundId!="")
        {
            GameController.Instance.StartRound(_selectedRoundId);
        } else
        {
            LoggingManager.AddErrorToLog("Try start round, but _selectedRoundId is empty");
        }
    }

    private void ActivateBtn(Button btn, bool activate)
    {
        btn.gameObject.SetActive(activate);
    }
    
    /* View round info
     * */
    private void ShoweBodyInformation()
    {
        if (_bodyIndex == 0)
        {
            ActivateBtn(_btnPrevious, false);
        }
        else
        {
            ActivateBtn(_btnPrevious, _bodyList.Count != 1);
        }

        if (_bodyIndex == _bodyList.Count-1)
        {
            ActivateBtn(_btnNext, false);
        }
        else
        {
            ActivateBtn(_btnNext, _bodyList.Count != 1);
        }

        _selectedRoundId = "";
        ActivateBtn(_btnPlay, false);
        SelectRound();

        if (_bodyViewController!=null)
        {
            if (_bodyViewController.bodyId!=_bodyList[_bodyIndex].id)
            {
                PrefabCreatorManager.Instance.DestroyPrefab(_bodyViewController.gameObject);
                _bodyViewController = PrefabBodyCreator.CreatBodyController(_bodyList[_bodyIndex]);
            } else
            {
                _bodyViewController.gameObject.SetActive(true);
            }
        }
        else
        {
            _bodyViewController = PrefabBodyCreator.CreatBodyController(_bodyList[_bodyIndex]);
        }

        
        BackgroundController.Instance.InitUIBg(_bodyList[_bodyIndex].uiBgImageUrl);
    }

    public override void DeActivate()
    {
        if (_bodyViewController!=null)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_bodyViewController.gameObject);
        }

        ResetViewList();
        base.DeActivate();
    }
    /*
     * reset round information 
     * */
    private void SelectRound()
    {
        _tfRoundName.text = "";
        _tfDescription.text = "Select infested Area";
        _tfBodyName.text = _bodyList[_bodyIndex].name;
        ResetVirusInformation();
    }

    private void RoundName(string roundName)
    {
        _tfRoundName.text = roundName;
    }

    private void CanPlay()
    {
        _tfDescription.text = "Push play for start";
    }

    private void CanNotPlay(List<string> roundsIds)
    {
        _tfDescription.text = "You need pass next rounds "+ roundsIds.ToString();
    }

    /*remove all view prefabs 
     * */
    private void ResetViewList()
    {

    }
    /*work with preview user anti bodies
     * */
    private void ShowUserAntiBodies()
    {
        List<String> antiBodiesList = GameModel.Instance.currentUserData.unlockedAntiBodyList;
        AntiBodyVO data;
        int i = 0;
        for (; i < antiBodiesList.Count; i++)
        {
            data = StaticDataModel.Instance.GetAntiBodyById(antiBodiesList[i]);
            if (data!=null)
            {
                if (i == _antiBodyPreviewList.Count)
                {
                    _antiBodyPreviewList.Add(PrefabAntBodyCreator.CreatAntiBodyPreview(_antiBodyPreviewContainer));
                }
                _antiBodyPreviewList[i].SetData(data);

            }
            else
            {
                LoggingManager.AddErrorToLog("Didnt found Anti body " + antiBodiesList[i] + " in UI");
            }
        }
        
        if (i<_antiBodyPreviewList.Count)
        {
            for (;i< _antiBodyPreviewList.Count;i++)
            {
                PrefabCreatorManager.Instance.DestroyPrefab(_antiBodyPreviewList[i].gameObject);
            }
        }
    }

    /*Viruses in current round
     * */
    private void ResetVirusInformation()
    {
        for (int i = 0; i<_virusesPreviewList.Count;i++)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_virusesPreviewList[i].gameObject);
        }
        
    }
    private void ShowInformationAboutViruses()
    {
        List<string> virusList = StaticDataModel.Instance.GetRoundById(_selectedRoundId).attackVirusesList;
        int i = 0;
        for (;i<virusList.Count;i++)
        {
            if (i==_virusesPreviewList.Count)
            {
                _virusesPreviewList.Add(PrefabVirusCreator.CreatVirusPreviwController(_virusesPreviewContainer));
            }
            _virusesPreviewList[i].SetData(StaticDataModel.Instance.GetVirusById(virusList[i]));
        }

        if (i<_virusesPreviewList.Count)
        {
            for (;i< _virusesPreviewList.Count;i++)
            {
                PrefabCreatorManager.Instance.DestroyPrefab(_virusesPreviewList[i].gameObject);
            }
        }
    }
    /*
     * prepare selected anty body list 
     **/
    private void PrepareUserSelectedAntiBodiesSlots()
    {
        int i = 0;
        for (;i<GameModel.Instance.currentUserData.slotsCounter;i++)
        {
            if (i == _antiBodySelectedList.Count)
            {
                _antiBodySelectedList.Add(PrefabAntBodyCreator.CreatAntiBodySelected(_antiBodySelectedContainer));
            }
            if (i<_antiBodySelectedId.Count)
            {
                _antiBodySelectedList[i].SetData(StaticDataModel.Instance.GetAntiBodyById(_antiBodySelectedId[i]));
            } else
            {
                _antiBodySelectedList[i].SetData(null);
            }
        }
        if (i < _antiBodySelectedList.Count)
        {
            for (;i< _antiBodySelectedList.Count;i++)
            {
                _antiBodySelectedList[i].SetData(null);
                PrefabCreatorManager.Instance.DestroyPrefab(_antiBodySelectedList[i].gameObject);
            }
        }
    }
    /*
    User action
    **/
    //player selec this antibody for round 
    public void SelectAntiBody(string antiBodyId)
    {
        if (_antiBodySelectedId.Count == GameModel.Instance.currentUserData.slotsCounter)
        {
            //TODO show user info about no empty slots for game 
        } else
        {
            for (int i = 0; i<_antiBodySelectedList.Count;i++)
            {
                if (_antiBodySelectedList[i].isEmpty)
                {
                    _antiBodySelectedList[i].SetData(StaticDataModel.Instance.GetAntiBodyById(antiBodyId));
                    _antiBodySelectedId.Add(antiBodyId);
                    return;
                }
            }
        }
    }
    //player return antibody 
    public void ReturnAntiBody(string antiBodyId)
    {
        for (int i = 0;i<_antiBodySelectedId.Count;i++)
        {
            if (_antiBodySelectedId[i] == antiBodyId)
            {
                _antiBodySelectedId.RemoveAt(i);
                return;
            }
        }
        LoggingManager.AddErrorToLog("Try return antibody " + antiBodyId + " but player didnt selected this antibody");
    }

    public void SelectRound(RoundVO round)
    {
        Debug.Log("SelectRound");
        List<string> needPassNexRounds = GameModel.Instance.CheckOnPassed(round.passedRoundsIds);
        _selectedRoundId = round.id;

        //show virus information in this round 
        ShowInformationAboutViruses();

        //show eound name 
        RoundName(round.name);

        if (needPassNexRounds.Count == 0)
        {
            ActivateBtn(_btnPlay, true);
            CanPlay();
        }
        else
        {
            ActivateBtn(_btnPlay, false);
            CanNotPlay(needPassNexRounds);
        }
    }
}

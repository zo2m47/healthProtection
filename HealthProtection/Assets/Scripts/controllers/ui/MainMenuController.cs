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
    [SerializeField]
    private GameObject _antiBodySelectedContainer;
    [SerializeField]
    private GameObject _virusesPreviewContainer;

    /* selected AB
     * */
    private List<int> _selectedAntyBodies = new List<int>();

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
        ResetViewList();
        ShowUserAntiBodies();

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

    private void ResetViewList()
    {
        _selectedAntyBodies = new List<int>();
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
    /*TF
     * */
    private void SelectRound()
    {
        _tfRoundName.text = "";
        _tfDescription.text = "Select infested Area";
        _tfBodyName.text = _bodyList[_bodyIndex].name;
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

    /*user anty bodies
     * */
    private void ShowUserAntiBodies()
    {
        List<String> antiBodiesList = GameModel.Instance.currentUserData.unlockedAntiBodyList;
        AntiBodyVO data;
        for (int i = 0; i < antiBodiesList.Count; i++)
        {
            data = StaticDataModel.Instance.GetAntiBodyById(antiBodiesList[i]);
            if (data!=null)
            {
                PrefabAntBodyCreator.CreatAntiBodyPreview(_antiBodyPreviewContainer).SetData(data);
            }
            else
            {
                LoggingManager.AddErrorToLog("Didnt found Anti body " + antiBodiesList[i] + " in UI");
            }
        }
    }

    /*Viruses in current round
     * */
    private void ShowInformationAboutViruses()
    {

    }

    /*
    User action
    **/
    
    public void SelectRound(RoundVO round)
    {
        Debug.Log("SelectRound");
        List<string> needPassNexRounds = GameModel.Instance.CheckOnPassed(round.passedRoundsIds);
        _selectedRoundId = round.id;
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

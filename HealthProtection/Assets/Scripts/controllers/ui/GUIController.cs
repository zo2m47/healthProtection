using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/*
 * Logic of UI in game 
 * */
public class GUIController : UIController
{
    [SerializeField]
    private GameObject _guiAntiBodySelectedContainer;
    private List<GuiAntiBodyController> _guiAntiBodySelectedList = new List<GuiAntiBodyController>();

    private int _unicIndificatorOfSelectedAntiBody = 0;
    protected override void GameObjectActivate()
    {
        CheckOnAllUIComponents();
        base.GameObjectActivate();
    }


    public override UINamesEnum uiName
    {
        get
        {
            return UINamesEnum.gui;
        }
    }

    protected override void CheckOnAllUIComponents()
    {
        if (_guiAntiBodySelectedContainer == null)
        {
            LoggingManager.AddErrorToLog("_guiAntiBodySelectedContainer doesnt exist");
        }

        Debug.Log("CheckOnAllUIComponents");
    }

    public override void Activate()
    {
        base.Activate();
        SetDefaultSetting();
    }

    public void ExitButtonClicked()
    {
        
    }

    private void SetDefaultSetting()
    {
        _unicIndificatorOfSelectedAntiBody = 0;
        int i = 0;
        for (i = 0; i<GameController.Instance.selectedAntiBodiesId.Count;i++)
        {
            if (i == _guiAntiBodySelectedList.Count)
            {
                _guiAntiBodySelectedList.Add(PrefabAntBodyCreator.CreatGuiAntiBody(_guiAntiBodySelectedContainer));
            }
            _guiAntiBodySelectedList[i].SetData(StaticDataModel.Instance.GetAntiBodyById(GameController.Instance.selectedAntiBodiesId[i]));
            _guiAntiBodySelectedList[i].SelectAntyBody(false);
        }

        for (;i< _guiAntiBodySelectedList.Count; i++)
        {
            PrefabCreatorManager.Instance.DestroyPrefab(_guiAntiBodySelectedList[i].gameObject);
        }
    }
    /**
     * work with anty body items
     * */
     
    public string TryShootAntyBody()
    {
        if(_unicIndificatorOfSelectedAntiBody == 0)
        {
            //TODO SHOW USER THAT he mus select smt
            return "";
        }
        for (int i = 0; i < _guiAntiBodySelectedList.Count; i++)
        {
            if (_guiAntiBodySelectedList[i].unicalId == _unicIndificatorOfSelectedAntiBody)
            {
                //if we can start so, return id of antibody
                if (_guiAntiBodySelectedList[i].TryToStartAttack())
                {
                    return _guiAntiBodySelectedList[i].id;
                }
                break;
            }
        }
        return "";
    }

    public void SelectNewAntiBody(int newUicIndificatorOfSelectedAntiBody)
    {
        if (newUicIndificatorOfSelectedAntiBody!= _unicIndificatorOfSelectedAntiBody)
        {
            for (int i = 0; i < _guiAntiBodySelectedList.Count; i++)
            {
                if (_guiAntiBodySelectedList[i].unicalId == newUicIndificatorOfSelectedAntiBody)
                {
                    _guiAntiBodySelectedList[i].SelectAntyBody(true);
                }
                if (_guiAntiBodySelectedList[i].unicalId == _unicIndificatorOfSelectedAntiBody)
                {
                    _guiAntiBodySelectedList[i].SelectAntyBody(false);
                }
            }
            _unicIndificatorOfSelectedAntiBody = newUicIndificatorOfSelectedAntiBody;
        }
    }
}

﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
/**
* Logic of UI 
* */
public class UIModel : ModelSingleTone<UIModel>
{
    [SerializeField]
    private UIController[] _uiList;
    public override void StartInitialization()
    {
        base.StartInitialization();
        for (int i = 0;i< _uiList.Length;i++)
        {
            _uiList[i].StartInitialization();
        }
    }

    //show first UI is MainMenuController
    protected override IEnumerator CheckOnInitialized()
    {
        bool allInitializated = false;
        while(!allInitializated) 
        {
            allInitializated = true;
            for (int i = 0; i < _uiList.Length; i++)
            {
                allInitializated = allInitializated && _uiList[i].allInitializated;
            }
            yield return null;
        }
        initializationStatus = InitializationStatus.initializated;
        yield break;
    }

    //hide all with exeption
    private void HideAllWitjExp(UINamesEnum eptName)
    {
        for (int i = 0; i < _uiList.Length; i++)
        {
            if (_uiList[i].uiName == eptName)
            {
                _uiList[i].Activate();
            }
            else
            {
                _uiList[i].DeActivate();
            }
        }
    }

    /*show UI view 
    */
    //start game, hide MainMenuController and show GUIMenu
    public void ShowGUI()
    {
        HideAllWitjExp(UINamesEnum.gui);
    }

    //hide all and show main meenu
    public void ShowMainMenu()
    {
        InputController.Instance.justOnlyDragInWorld = true;
        HideAllWitjExp(UINamesEnum.mainMenu);
    }

    /*show popup dont hide currend UI just show selected popup
    */
    public void ShowPopUp(PopUpNameEnum popupName)
    {
        HideAllWitjExp(UINamesEnum.popup);
        popUpManager.ShovePopUp(popupName);
    }

    /*get ui controllers 
    */
    public GUIController guiController
    {
        get
        {
            return GetUiByName(UINamesEnum.gui) as GUIController;
        }
    }

    public MainMenuController mainMenuController
    {
        get
        {
            return GetUiByName(UINamesEnum.mainMenu) as MainMenuController;
        }
    }

    public PopUpManager popUpManager
    {
        get
        {
            return GetUiByName(UINamesEnum.popup) as PopUpManager;
        }
    }

    public UIController GetUiByName(UINamesEnum uiName)
    {
        for (int i = 0; i < _uiList.Length; i++)
        {
            if (_uiList[i].uiName == uiName)
            {
                return _uiList[i];
            }
        }

        LoggingManager.AddErrorToLog("Didnt found ui");
        return null;
    }
}

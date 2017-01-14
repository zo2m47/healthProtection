using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUIController : UIController
{
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
    
    }
}

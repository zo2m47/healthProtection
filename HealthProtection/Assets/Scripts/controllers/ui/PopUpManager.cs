using System.Collections.Generic;
using UnityEngine;
public class PopUpManager : UIController
{
    [SerializeField]
    private PopUpController[] _popUpList;

    public int popUpListLength = 0;
   
    protected override void GameObjectActivate()
    {   
        if (_popUpList == null)
        {
            _popUpList = gameObject.GetComponentsInChildren<PopUpController>();
            popUpListLength = _popUpList.Length;
        }
        base.GameObjectActivate();
    }

    public override void Activate()
    {
        base.Activate();
    }

    public override void DeActivate()
    {
        base.DeActivate();
    }

    public override UINamesEnum uiName
    {
        get
        {
            return UINamesEnum.popup;
        }
    }
    //show selected popup and hide other popups 
    public void ShovePopUp(PopUpNameEnum popUpName)
    {
        Activate();
        for (int i = 0;i<_popUpList.Length;i++)
        {
            if (_popUpList[i].popupName == popUpName)
            {
                _popUpList[i].Activate();
            } else
            {
                _popUpList[i].DeActivate();
            }
        }
    }
}

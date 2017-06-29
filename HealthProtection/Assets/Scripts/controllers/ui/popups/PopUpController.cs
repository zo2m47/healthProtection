using System;
using UnityEngine;
public class PopUpController:MonoBehaviour, IPopUpController
{
    /* IPopUpController r
     * */
    public virtual PopUpNameEnum popupName { get { return PopUpNameEnum.notIdentified; } }
    
    public virtual void Activate()
    {
        if (!gameObject.active)
        {
            gameObject.SetActive(true);
        }
    }

    public virtual void DeActivate()
    {
        if (gameObject.active)
        {
            gameObject.SetActive(false);
        }
    }

    public virtual void SetData(object someData)
    {
        
    }

    protected virtual void SetDefaultSettings()
    {

    }
}

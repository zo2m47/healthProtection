using System;
using UnityEngine;
public class PopUpController:MonoBehaviour
{
    public virtual PopUpNameEnum popupName
    {
        get
        {
            return PopUpNameEnum.notIdentified;
        }
    }

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
}

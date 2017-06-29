using System;
using System.Collections.Generic;

public interface IPopUpController
{
    PopUpNameEnum popupName { get; }
    void Activate();
    void DeActivate();
    void SetData(object someData);
}

using System;
using UnityEngine;
public class ControllerSingleTone<T> : SingletonMonoBehaviour<T> where T : ControllerSingleTone<T>
{
    public override string gameObjecName
    {
        get
        {
            return GameObjectNames.CONTROLLER_OBJECT_NAME;
        }
    }
}

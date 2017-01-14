using System;
using UnityEngine;
public class ManagerSingleTone<T> : SingletonMonoBehaviour<T> where T : ManagerSingleTone<T>
{
    public override string gameObjecName
    {
        get
        {
            return GameObjectNames.MANAGER_OBJECT_NAME;
        }
    }
}


using UnityEngine;
using System.Collections;
using System;

public class ModelSingleTone<T> : SingletonMonoBehaviour<T>, IInitilizationProcess where T:ModelSingleTone<T>
{
    public InitializationStatus initializationStatus { get; protected set; }

    //initialization process
    public virtual void StartInitialization()
    {
        initializationStatus = InitializationStatus.inProgress;
        StartCoroutine(CheckOnInitialized());
    }
    
    protected virtual IEnumerator CheckOnInitialized()
    {
        initializationStatus = InitializationStatus.initializated;
        yield break;
    }

    public virtual bool allInitializated
    {
        get
        {
            if (initializationStatus == InitializationStatus.waiting)
            {
                return false;
            }
            return initializationStatus == InitializationStatus.initializated;
        }
    }

    public override string gameObjecName
    {
        get
        {
            return GameObjectNames.MODEL_OBJECT_NAME;
        }
    }
}
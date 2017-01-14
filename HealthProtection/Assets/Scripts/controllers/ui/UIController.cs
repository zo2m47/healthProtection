using UnityEngine;
using System.Collections;
using System;

public class UIController : MonoBehaviour, IInitilizationProcess
{
    //IInitilizationProcess
    public InitializationStatus initializationStatus { get; protected set; }

    public void Start()
    {
        GameObjectActivate();
    }

    public bool allInitializated
    {
        get
        {
            return initializationStatus == InitializationStatus.initializated;
        }
    }

    public virtual void StartInitialization()
    {
        if (initializationStatus == InitializationStatus.initializated)
        {
            return;
        }
        initializationStatus = InitializationStatus.inProgress;
        gameObject.SetActive(true);
    }

    protected virtual void GameObjectActivate()
    {
        initializationStatus = InitializationStatus.initializated;
        gameObject.SetActive(false); 
    }

    //IUIController
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

    protected virtual void CheckOnAllUIComponents()
    {

    }

    protected virtual void SetDefaultSetting()
    {

    }

    public virtual UINamesEnum uiName
    {
        get
        {
            return UINamesEnum.notIdentified;
        }
    }
}

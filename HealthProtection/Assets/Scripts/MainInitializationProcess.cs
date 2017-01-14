using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * Initializate all controllers for starts
 * Nedd add this class to main unity project
 * */
public class MainInitializationProcess : SingletonMonoBehaviour<MainInitializationProcess>
{
    public InitializationStatus initializationStatus { get; private set; }
    private int _initializationIndex = 0;
    private List<IInitilizationProcess> _initializationList = new List<IInitilizationProcess>();
    public void Start()
    {
        Debug.Log("Start initializate");
        _initializationList.Add(BackgroundController.Instance);
        _initializationList.Add(StaticDataModel.Instance);
        _initializationList.Add(GameModel.Instance);
        _initializationList.Add(UIModel.Instance);
        _initializationList.Add(SoundModel.Instance);
        StartInitialization();
    }

    //start initialization process
    public void StartInitialization()
    {
        StartCoroutine(StartInitializateModel());
    }

    private IEnumerator StartInitializateModel()
    {
        yield return new WaitForSeconds(1);
        StartCoroutine(CheckOnInitializationModel());
    }
    //initializat all model step by step 
    private IEnumerator CheckOnInitializationModel()
    {
        while (_initializationIndex < _initializationList.Count)
        {
            
            if (_initializationList[_initializationIndex].initializationStatus == InitializationStatus.waiting)
            {
                _initializationList[_initializationIndex].StartInitialization();
            }

            if (_initializationList[_initializationIndex].initializationStatus == InitializationStatus.initializationError)
            {
                LoggingManager.AddErrorToLog(string.Format("!!--initializationError in next index {0}", _initializationIndex));
                yield break;
            }

            if (_initializationList[_initializationIndex].allInitializated)
            {
                _initializationIndex++;
            }

            yield return null;
        }
        Debug.Log("All models were initializated");
        initializationStatus = InitializationStatus.initializated;
        UIModel.Instance.ShowMainMenu();
        yield break;
    }
    
    public bool allInitializated
    {
        get
        {
            return initializationStatus == InitializationStatus.initializated;
        }
    }
}

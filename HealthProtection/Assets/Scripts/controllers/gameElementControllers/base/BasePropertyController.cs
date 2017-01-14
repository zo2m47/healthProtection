using UnityEngine;
using System.Collections;
/**
 * Base property controller of othe game elements
 * */
public class BasePropertyController<T, S> : MonoBehaviour where T : GameElementBaseController<S>
{
    protected virtual string traceName { get { return "BaseGameElementController"; } }
    protected T _gameController;
    // Use this for void
    //initialization 
    public void Start()
    {
        _gameController = GetComponentInParent<T>();
        if (_gameController == null)
        {
            LoggingManager.AddErrorToLog("Didnt found GameController "+ traceName);
        }
        InitDelegate();
    }

    protected S staticData
    {
        get
        {
            return _gameController.staticData;
        }
    }

    protected virtual void InitDelegate()
    {
        //overide in parent 
    }
}

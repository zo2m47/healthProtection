using System.Collections.Generic;
using UnityEngine;
/**
 * Collect all errors in game
 * */
public class LoggingManager:ControllerSingleTone<LoggingManager>
{
    private List<string> _loggindList = new List<string>();

    public void AddLog(string message)
    {
        Debug.Log(message);
        _loggindList.Add(message);
    }

    public static void AddErrorToLog(string error)
    {
        LoggingManager.Instance.AddLog("<!><!><!> ERROR - " + error);
    }
}

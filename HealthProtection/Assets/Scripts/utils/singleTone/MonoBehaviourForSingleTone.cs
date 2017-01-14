using UnityEngine;
using System.Collections.Generic;
/**
 * Creat single tone og game object
 * */
public class MonoBehaviourForSingleTone : MonoBehaviour {
    //name of gameObject container
    private const string MAIN_GO = "SingleToneClasses";
    private static GameObject _s_mainScriptsContainer;
    private static Dictionary<string, GameObject> _s_singleToneContainers = new Dictionary<string, GameObject>();

    protected static T SingletonMonoBehaviourInstance<T>() where T:SingletonMonoBehaviour<T>
    {
        if (_s_mainScriptsContainer == null)
        {
            _s_mainScriptsContainer = new GameObject(MAIN_GO);
        }
        //creat game obgect to add component there
        GameObject currentScriptGO = new GameObject("tempGO");
        currentScriptGO.AddComponent<T>();

        T instance = currentScriptGO.GetComponent<T>();
        
        string currentGOName = instance.GetType().Name;
        string parentGOName = instance.gameObjecName;

        currentScriptGO.name = currentGOName;

        if (parentGOName == "")
        {
            parentGOName = GameObjectNames.DEFAULT_NAME;
        }
        if (!_s_singleToneContainers.ContainsKey(parentGOName))
        {
            GameObject go = new GameObject(parentGOName);
            go.transform.parent = _s_mainScriptsContainer.transform;

            _s_singleToneContainers.Add(parentGOName, go);
        }
        
        currentScriptGO.transform.parent = _s_singleToneContainers[parentGOName].transform;
        return instance;
    }
    
}

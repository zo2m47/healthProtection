
using System;
using System.Collections.Generic;
using UnityEngine;

public class CollectionOfData<T> where T:DataVO
{
    //Dictionary with elements of static where key is id static data elemtn
    private Dictionary<string,T> _collaction;
    private List<T> _list;
    //uses for error logging
    private string _collactionName = "";

    public void InitCollaction(string staticFileName)
    {
        Debug.Log("Start initialization "+ staticFileName);
        _collactionName = staticFileName;
        StaticResourcesXmlLoader<T> container = StaticResourcesXmlLoader<T>.LoadContainer(UrlXmls.staticData+staticFileName);
        _collaction = new Dictionary<string, T>();
        _list = new List<T>();
        foreach (T data in container.dataList)
        {
            if (!_collaction.ContainsKey(data.id))
            {
                _collaction.Add(data.id, data);
                _list.Add(_collaction[data.id]);
            } else
            {
                LoggingManager.AddErrorToLog("Repeated static data element with id "+ data.id);
            }
        }
        Debug.Log(staticFileName+" ready");
    }

    public T GetDataById(string id)
    {
        if (_collaction.ContainsKey(id))
        {
            return _collaction[id];
        }
        LoggingManager.AddErrorToLog("Did't found data with id "+id+" in collection "+_collactionName);
        return null;
    }

    public Dictionary<string, T> collaction
    {
        get
        {
            return _collaction;
        }
    }

    public List<T> list
    {
        get
        {
            return _list;
        }
    }
}

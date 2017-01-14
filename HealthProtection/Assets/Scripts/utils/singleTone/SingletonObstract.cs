﻿using UnityEngine;
/**
 * uses to controlling singletone of data classes
 * */
  
public class SingletonObstract<T> where T: new()
{
    private static T _instance;
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new T();
            }
            return _instance;
        }
    }
}


using System.Collections.Generic;
using UnityEngine;

public class PrefabCreatorManager : ManagerSingleTone<PrefabCreatorManager>
{
    private Dictionary<RecycleGameObjectManager, ObjectPoolManager> _pools = new Dictionary<RecycleGameObjectManager, ObjectPoolManager>();
    private GameObject _gameObjectsPool;

    //creat prefab 
    public GameObject InstanceOfPrefab(string prefabUrl, Vector3 pos = default(Vector3), GameObject container = null,float xScale = 1,float yScale = 1,bool withScaleSetter = true, bool withPositionSetter = true)
    {
        //try to load prefab from resources folder 
        GameObject go = Resources.Load(prefabUrl, typeof(GameObject)) as GameObject;
        if (go == null)
        {
            LoggingManager.AddErrorToLog("Didnt found prefab " + prefabUrl);
        }
        //try get RecycleGameObjectController, if it, so get it frome pool
        var recycledScript = go.GetComponent<RecycleGameObjectManager>();
        GameObject instance = null;

        if (recycledScript != null)
        {
            var pool = GetObjectPool(recycledScript);
            instance = pool.NextObject().gameObject;
        }
        else
        {
            //creat brefab instance
            instance = Instantiate(go) as GameObject;
        }

        if (container!=null)
        {
            //add prefab to container
            instance.transform.SetParent(container.transform);
        }
        if (withScaleSetter)
        {
            instance.transform.localScale = new Vector3(xScale, yScale, 1);
        }
        if (withPositionSetter)
        {
            instance.transform.position = pos;
        }
        return instance;
    }

    private ObjectPoolManager GetObjectPool(RecycleGameObjectManager reference)
    {
        ObjectPoolManager pool = null;

        if (_pools.ContainsKey(reference))
        {
            pool = _pools[reference];
        }
        else
        {
            if(_gameObjectsPool == null)
            {
                _gameObjectsPool = new GameObject("GameObjectsPool");
            }
            GameObject poolContainer = new GameObject(reference.gameObject.name + "ObjectPool");
            poolContainer.layer = reference.gameObject.layer;
            poolContainer.transform.parent = _gameObjectsPool.transform;
            pool = poolContainer.AddComponent<ObjectPoolManager>();
            pool.prefab = reference;
            _pools.Add(reference, pool);
        }

        return pool;
    }
    //destroy prefab 
    public void DestroyPrefab(GameObject gameObject)
    {
        if (gameObject == null)
        {
            return;
        }

        var recyleGameObject = gameObject.GetComponent<RecycleGameObjectManager>();

        if (recyleGameObject != null)
        {
            recyleGameObject.Shutdown();
        }
        else
        {
            GameObject.Destroy(gameObject);
        }
    }

    //return component from created prefab 
    public CMP InstanceComponent<CMP>(string prefabUrl,Vector3 pos = default(Vector3), GameObject container = null,float xScale = 1f,float yScale = 1f, bool withScaleSetter = true, bool withPositionSetter = true) where CMP : Component
    {
        CMP returnClass = InstanceOfPrefab(prefabUrl, pos, container, xScale, yScale, withScaleSetter, withPositionSetter).GetComponent(typeof(CMP)) as CMP;
        if(returnClass == null)
        {
            LoggingManager.AddErrorToLog("Didnt found component "+ typeof(CMP) +" in prefab "+ prefabUrl);
        }
            return returnClass;
    }
}

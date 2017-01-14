using UnityEngine;
/**
Creat InfestedArea settings 
    **/
public class PrefabInfestedAreaCreator
{
    public static InfestedAreaController CreatInfestedAreaPrefab(Vector3 position)
    {
        return PrefabCreatorManager.Instance.InstanceComponent<InfestedAreaController>(UrlPrefabs.infestedArea, position);
    }
}

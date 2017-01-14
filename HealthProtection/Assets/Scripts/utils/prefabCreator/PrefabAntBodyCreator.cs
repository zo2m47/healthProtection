using UnityEngine;
/**
 * controll anibodies prefabs creator
 * */
public class PrefabAntBodyCreator
{
    //creat instance for game process
    public static AntiBodyBaseGameController CreatAntiBody(AntiBodyVO antiBody,Vector3 position)
    {
        return PrefabCreatorManager.Instance.InstanceComponent<AntiBodyBaseGameController>(antiBody.viewPrefabUrl, position);
    }
    //creat instance for ui 
    public static PreviewAntiBodyController CreatAntiBodyPreview(GameObject go)
    {
        string prefabUrl = UrlPrefabs.antiBodyPreviewItem;
        return PrefabCreatorManager.Instance.InstanceComponent<PreviewAntiBodyController>(prefabUrl, Vector3.zero, go,1,1,false,false);
    }
}

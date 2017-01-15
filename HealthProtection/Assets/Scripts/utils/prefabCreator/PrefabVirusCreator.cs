using UnityEngine;
public class PrefabVirusCreator
{
    public static void CreatVirusGameController(VirusVO virusData,Vector3 position)
    {
        PrefabCreatorManager.Instance.InstanceComponent<VirusBaseGameController>(virusData.viewPrefabUrl, position).SetStaticData(virusData);
    }

    public static PreviewVirusController CreatVirusPreviwController(GameObject container)
    {
        return PrefabCreatorManager.Instance.InstanceComponent<PreviewVirusController>(UrlPrefabs.virusPreviewItem, Vector3.zero, container, 1, 1, false, false);
    }

}

using UnityEngine;
public class PrefabVirusCreator
{
    public static void CreatVirusGameController(VirusVO virusData,Vector3 position)
    {
        PrefabCreatorManager.Instance.InstanceComponent<VirusBaseGameController>(virusData.viewPrefabUrl, position).SetStaticData(virusData);
    }
}

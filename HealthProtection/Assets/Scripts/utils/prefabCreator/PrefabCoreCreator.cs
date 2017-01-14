public class PrefabCoreCreator
{
    public static ICoreGameController CreatCore(CoreVO core)
    {
        return PrefabCreatorManager.Instance.InstanceOfPrefab(core.viewPrefabUrl).GetComponent<ICoreGameController>();
    }
}

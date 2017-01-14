using UnityEngine;
public class PrefabParallaxCreator
{
    public static ParallaxController CreatParallax()
    {
        return PrefabCreatorManager.Instance.InstanceComponent<ParallaxController>(UrlPrefabs.parallax, Vector3.zero);
    }
}

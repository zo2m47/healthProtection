public class PrefabRoundCreator
{
    public static IRoundGameController CreatRoundGameController(RoundVO round)
    {
        return PrefabCreatorManager.Instance.InstanceOfPrefab(round.bgViewPrefabUrl).GetComponent<IRoundGameController>();
    }
}

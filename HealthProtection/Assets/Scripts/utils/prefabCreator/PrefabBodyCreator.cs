/**
 *  settings of creat body prefabs 
 * */
public class PrefabBodyCreator
{
    public static BodyViewController CreatBodyController(BodyVO body)
    {
        BodyViewController res = PrefabCreatorManager.Instance.InstanceComponent<BodyViewController>(body.viewPrefabUrl);

        res.SetData(body);
        return res;
    }
}

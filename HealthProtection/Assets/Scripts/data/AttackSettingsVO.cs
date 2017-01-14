using UnityEngine;
/**
 * rattack setting in round
 * */
public class AttackSettingVO
{
    private Vector3 _startPosition;
    public Vector3 startPosition { get { return _startPosition; } }

    private VirusVO _virusData;
    public VirusVO virusData { get { return _virusData; } }

    
    public AttackSettingVO(string lvirus)
    {
        _virusData = StaticDataModel.Instance.GetVirusById(lvirus);
        _startPosition = GetRandomPosition();
    }

    private Vector3 GetRandomPosition()
    {
        Vector3 position = Vector3.zero;
        int rand = Random.Range(1, 5);
        int halhWidth = (int)Mathf.Round(BackgroundController.Instance.bgWidth / 2);
        int halhHeight = (int)Mathf.Round(BackgroundController.Instance.bgHeight / 2);
        switch ((SideEnum)rand)
        {
            // LEFT 
            case SideEnum.left:
                position.x = -halhWidth;
                position.y = Random.Range(-halhHeight, halhHeight);
                break;
            // TOP 
            case SideEnum.top:
                position.x = Random.Range(-halhWidth, halhWidth);
                position.y = -halhHeight;
                break;
            // RIGHT
            case SideEnum.right:
                position.x = halhWidth;
                position.y = Random.Range(-halhHeight, halhHeight);
                break;
            //BOTTOM
            case SideEnum.bottom:
                position.x = Random.Range(-halhWidth, halhWidth);
                position.y = halhHeight;
                break;

        }
        return position;
    }
}

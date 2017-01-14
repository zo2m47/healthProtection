using UnityEngine;
/**
 * Class with Direction settings 
 * **/
public class AttackDirectionVO
{
    private SideEnum _side;
    public SideEnum side { get { return _side; } }

    private Vector3 _finishPosition;
    public Vector3 finishPosition { get { return _finishPosition; } }

    private Vector3 _startPosition;
    public Vector3 startPosition { get { return _startPosition; } }

    private float _rotation;
    public float rotation { get { return _rotation; } }

    public AttackDirectionVO(Vector3 touchCoordinate)
    {
        touchCoordinate.z = 0;
        _side = GetSideEnumByCoordinate(touchCoordinate);
        _startPosition = StartPosition(touchCoordinate);
        _finishPosition = FinishPosition(touchCoordinate);
        _rotation = Rotation();
    }

    private float Rotation()
    {
        int res = 0;
        switch (_side)
        {
            case SideEnum.left:
                res = 0;
                break;
            case SideEnum.top:
                res = -90;
                break;
            case SideEnum.right:
                res = 180;
                break;
            case SideEnum.bottom:
                res = 90;
                break;
            default:
                break;
        }
        return res;
    }

    private Vector3 StartPosition(Vector3 touchCoordinate)
    {
        Vector3 res = Vector3.zero;
        switch (_side)
        {
            case SideEnum.left:
                res.x = -BackgroundController.Instance.bgWidth / 2;
                res.y = touchCoordinate.y;
                break;
            case SideEnum.top:
                res.x = touchCoordinate.x;
                res.y = BackgroundController.Instance.bgHeight/2;
                break;
            case SideEnum.right:
                res.x = BackgroundController.Instance.bgWidth / 2;
                res.y = touchCoordinate.y;
                break;
            case SideEnum.bottom:
                res.x = touchCoordinate.x;
                res.y = -BackgroundController.Instance.bgHeight / 2;
                break;
            default:
                break;
        }
        return res;
    }

    private Vector3 FinishPosition(Vector3 touchCoordinate)
    {
        Vector3 res = Vector3.zero;
        switch (_side)
        {
            case SideEnum.left:
                res.x = BackgroundController.Instance.bgWidth / 2;
                res.y = touchCoordinate.y;
                break;
            case SideEnum.top:
                res.x = touchCoordinate.x;
                res.y = -BackgroundController.Instance.bgHeight / 2;
                break;
            case SideEnum.right:
                res.x = -BackgroundController.Instance.bgWidth / 2;
                res.y = touchCoordinate.y;
                break;
            case SideEnum.bottom:
                res.x = touchCoordinate.x;
                res.y = BackgroundController.Instance.bgHeight / 2;
                break;
            default:
                break;
        }
        return res;
    }

    public SideEnum GetSideEnumByCoordinate(Vector3 touchCoordinate)
    {
        float distanceByX = BackgroundController.Instance.bgWidth / 2 - Mathf.Abs(touchCoordinate.x);
        float distanceByY = BackgroundController.Instance.bgHeight / 2 - Mathf.Abs(touchCoordinate.y);
        SideEnum sideEnum;

        if (distanceByX<distanceByY)
        {
            if (touchCoordinate.x<0)
            {
                sideEnum = SideEnum.left;
            } else
            {
                sideEnum = SideEnum.right;
            }
        } else
        {
            if (touchCoordinate.y < 0)
            {
                sideEnum = SideEnum.bottom;
            }
            else
            {
                sideEnum = SideEnum.top;
            }
        }
        return sideEnum;
    }
}

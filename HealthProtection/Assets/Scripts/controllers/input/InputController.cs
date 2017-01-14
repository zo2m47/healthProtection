using UnityEngine;
/**
 * Controll of input 
 * */
public class InputController : ControllerSingleTone<InputController>, ITouchCommand
{
    private const int START_DRAG_TIMER = 10;
    private const float SPEED_DRAG_TIMER = 1;

    private RaycastHit2D _hit;
    private ITouchCommand _touchCommand;

    private float _touchTimer;
    private bool _draging;
    private bool _touched;

    private Vector3 _oldTouchPosition;
    private Vector3 _newTouchPosition;

    //in main menu 
    private bool _justOnlyDragInWorld = false;
    public bool justOnlyDragInWorld{set{_justOnlyDragInWorld = value;}}

    //take touch position, after touch started, call frome child
    protected void TouchedInPosition(Vector3 startPosition)
    {
        if (_touched)
        {
            return;
        }
        _newTouchPosition = Camera.main.ScreenToWorldPoint(startPosition);
        _touched = true;
        _touchTimer = 0;
        GetHitRay();
    }

    //stop touched, call frome child   
    protected void StopTouched()
    {
        if (_touched)
        {
            TouchClick();
        }
        if (_draging)
        {
            TouchStopDrag();
        }
    }

    protected void GetHitRay()
    {
        _hit = Physics2D.Raycast(_newTouchPosition, Vector2.zero);
        if (_hit && _hit.collider!=null)
        {
            //if game object has TouchCommand
            _touchCommand = _hit.collider.gameObject.GetComponent<ITouchCommand>();
            if (_touchCommand != null)
            {
                return;
            }
        }
        _touchCommand = null;
    }
    //call by child ever Frame in childe update function
    protected void ChekOnTouching(Vector3 newPosition)
    {
        if (_touched)
        {
            //dont use Just for current game
            //if dont need touch to space world, can uncomant 
            if (_touchCommand == null && _justOnlyDragInWorld)
            {
                TouchStartDrag();
            }
            //else
            //{
            //if touch some time, so start draging;
            if (_touchTimer < START_DRAG_TIMER)
                {
                    _touchTimer += SPEED_DRAG_TIMER + Time.deltaTime;
                }
                else
                {
                    //if (draggable)
                    //{
                        TouchStartDrag();
                    //}
                }
            //}
        }

        if (_draging)
        {
            TouchMoved(newPosition);
        }

    }

    //functions from interface
    public void TouchClick()
    {
        _touched = false;
        if (_touchCommand != null)
        {
            _touchCommand.TouchClick();
        }
        //Just for current game
        else
        {
            GameController.Instance.TouchCordinat(_newTouchPosition);
        }
    }

    public void TouchMoved(Vector3 movedPosition)
    {
        _oldTouchPosition = _newTouchPosition;
        _newTouchPosition = Camera.main.ScreenToWorldPoint(movedPosition);
        //if touched object is not draggable will start dragging of camera
        if (draggable)
        {
            _touchCommand.TouchMoved(_newTouchPosition- _oldTouchPosition);
        }
        else
        {
            Vector3 move = _oldTouchPosition - _newTouchPosition;
            CameraNavigationManager.Instance.MoveToNewPosition(move);
        }
    }

    public void TouchStartDrag()
    {
        _touched = false;
        _draging = true;
        if (draggable)
        {
            _touchCommand.TouchStartDrag();
        }
    }

    public void TouchStopDrag()
    {
        _draging = false;
        if (draggable)
        {
            _touchCommand.TouchStopDrag();
        }
    }

    public bool draggable
    {
        get
        {
            return (_touchCommand != null && _touchCommand.draggable);
        }
    }
}

using UnityEngine;
using UnityEngine.UI;
/**
 * Controller of prefab selected antibody view 
 * 
 * */
public class SelectedAntiBodyController : MonoBehaviour, ITouchCommand
{
    [SerializeField]
    private Image _image;

    //static data of current anti body
    private AntiBodyVO _data;

    public void Start()
    {
        if (_image == null)
        {
            LoggingManager.AddErrorToLog("_image Doesn't exist in SelectedAntiBodyController");
        }
    }
    
    public void SetData(AntiBodyVO l_data)
    {
        _data = l_data;
        if (_data == null)
        {
            _image.sprite = null;
        }
        else
        {
            _image.sprite = Resources.Load<Sprite>(_data.viewImageUrl);
        }
    }

    public void ClickEvent()
    {
        //TODO call method in mainMenu 
    }

    public string id
    {
        get
        {
            if (_data == null)
            {
                return "";
            }

            return _data.id;
        }

    }
    
    /*ITouchCommand release 
     * */
    public bool draggable
    {
        get
        {
            return true;
        }
    }

    public void TouchClick()
    {

    }

    public void TouchMoved(Vector3 movedPosition)
    {

    }

    public void TouchStartDrag()
    {
        //TODO show view with info 
    }

    public void TouchStopDrag()
    {
        //TODO hide view with info 
    }
}

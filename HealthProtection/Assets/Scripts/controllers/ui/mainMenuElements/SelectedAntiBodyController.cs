using UnityEngine;
using UnityEngine.UI;
/**
 * Controller of prefab selected antibody view 
 * 
 * */
public class SelectedAntiBodyController : UiElementTouchableController
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
            _image.sprite = Resources.Load<Sprite>(UrlImages.emptyAntiBody);
        }
        else
        {
            _image.sprite = Resources.Load<Sprite>(_data.viewImageUrl);
        }
    }

    public bool isEmpty
    {
        get
        {
            return _data == null;
        }
    }

    protected override void Click()
    {
        if (_data != null)
        {
            UIModel.Instance.mainMenuController.ReturnAntiBody(_data.id);
        }
    }
}

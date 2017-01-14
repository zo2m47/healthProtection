using System;
using UnityEngine;
using UnityEngine.UI;
/**
 * controller of anti body in mainMenu preview 
 * */
public class PreviewAntiBodyController : MonoBehaviour, ITouchCommand
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _tfName;

    private AntiBodyVO _data;
    private bool _selected = false;

    public void Start()
    {
        if (_image == null)
        {
            _image = gameObject.GetComponent<Image>();
        }
        if (_tfName == null)
        {
            _tfName = gameObject.GetComponent<Text>();
        }
    }
    // set static data;
    public void SetData(AntiBodyVO l_data)
    {
        _data = l_data;
        _image.sprite = Resources.Load<Sprite>(_data.viewImageUrl);
        _tfName.text = _data.name;
    }

    public void ClickedEvent()
    {
        if (_selected)
        {
            ReturnAntiBody();
        }
        else
        {
            SelectAntiBody();
        }
    }
    //delegate
    private void DegateListener()
    {
        PrefabCreatorManager.Instance.DestroyPrefab(gameObject);
    }

    //user select this defender item 
    private void SelectAntiBody()
    {
        _selected = true;
        //TODO call method to selected anti body
    }
    //user return to list this defender item
    private void ReturnAntiBody()
    {
        _selected = false;
        //TODO call method to return anti body
    }

    public bool selected
    {
        set
        {
            _selected = value;
            _image.color = _selected ? Color.black : Color.white;
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
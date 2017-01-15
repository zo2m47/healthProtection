using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
/**
 * controller of anti body in mainMenu preview 
 * */
public class PreviewAntiBodyController : UiElementTouchableController
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _tfName;

    private AntiBodyVO _data;

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

        if (!gameObject.active) {
            gameObject.SetActive(true);
        };
    }

    //user select this defender item 
    protected override void Hold()
    {
        
    }

    protected override void Click()
    {
        UIModel.Instance.mainMenuController.SelectAntiBody(_data.id);
    }
}
using System;
using UnityEngine;
using UnityEngine.UI;
/**
 * Controller of beetle preview in main menu 
 * 
 * */
public class PreviewVirusController : UiElementTouchableController
{
    [SerializeField]
    private Image _image;

    [SerializeField]
    private Text _tfName;

    private VirusVO _data;

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
    // set beetle data;
    public void SetData(VirusVO l_data)
    {
        _data = l_data;
        _image.sprite = Resources.Load<Sprite>(_data.viewImageUrl);
        _tfName.text = _data.name;
        if (!gameObject.active)
        {
            gameObject.SetActive(true);
        }
    }
  
}

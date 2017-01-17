using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/*
* Logic of antibody element in GUI menu 
*/
public class GuiAntiBodyController : UiElementTouchableController {
    private static int _s_unicalId = 1;
    [SerializeField]
    private Image _antyBodyImage;

    [SerializeField]
    private Image _coolDownImage;

    [SerializeField]
    private Image _selectedImage;

    private AntiBodyVO _data;

    private int _unicalId = 0;
    public int unicalId { get { return _unicalId; } }
    private bool _avaibleToUse;

    private void Start()
    {
        _s_unicalId++;
        _unicalId = _s_unicalId;
    }

    public void SetData(AntiBodyVO l_data)
    {
        _data = l_data;
        _avaibleToUse = true;
        _coolDownImage.fillAmount = 0;
        if (_data == null)
        {
            _antyBodyImage.sprite = Resources.Load<Sprite>(UrlImages.emptyAntiBody);
        }
        else
        {
            _antyBodyImage.sprite = Resources.Load<Sprite>(_data.viewImageUrl);
        }
    }

    //overide UiElementTouchableController methods

    protected override void Click()
    {
        base.Click();
        if (_data!=null)
        {
            //call method that this element was selected 
            UIModel.Instance.guiController.SelectNewAntiBody(_unicalId);
        }
    }

    private IEnumerator StartReload()
    {
        _avaibleToUse = false;
        _coolDownImage.fillAmount = 1.0f;
        while (_coolDownImage.fillAmount > 0 && !_avaibleToUse)
        {
            _coolDownImage.fillAmount -= 1.0f / _data.reloadDuration* Time.deltaTime;
            yield return null;
        }
        _coolDownImage.fillAmount = 0;
        _avaibleToUse = true;
        yield break;
    }
    
    //colls from GUI controller
    public bool TryToStartAttack()
    {
        //if anti bodies no ready, return false, and game model doesnt creat instance of attack 
        if (!_avaibleToUse)
        {
            return false;
        }
        // else start cooldawn and creat instance of prefab in fame controller 
        StartCoroutine(StartReload());
        return true;
    }

    public void SelectAntyBody(bool value)
    {
        _selectedImage.gameObject.SetActive(value);
    }

    public string id
    {
        get
        {
            return _data.id;
        }
    }
}

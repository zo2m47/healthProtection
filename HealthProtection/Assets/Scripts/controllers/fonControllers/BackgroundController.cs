using System;
using UnityEngine;
/**
 * Controll bg coordinate and size 
 * */
public class BackgroundController : ControllerSingleTone<BackgroundController>, IInitilizationProcess
{
    //original background size like 1920 /1200
    private float _bgWidth = 0;
    private float _bgHeight = 0;
    private float _pixelPerUnit = 0f;
    private Vector3 _size;
    private string _lostLoadedImage = "";
    private SpriteRenderer _bgSprite;

    private InitializationStatus _initializationStatus;

    public InitializationStatus initializationStatus
    {
        get
        {
            return _initializationStatus;
        }
    }

    public bool allInitializated
    {
        get
        {
            return _initializationStatus == InitializationStatus.initializated;
        }
    }

    public void StartInitialization()
    {
        _bgSprite = GetComponent<SpriteRenderer>();
        if (_bgSprite == null)
        {
            LoggingManager.AddErrorToLog("Canot found BG image");
            _initializationStatus = InitializationStatus.initializationError;
            return;
        }
        _initializationStatus = InitializationStatus.initializated;
    }

    public void InitRoundBg(RoundVO round)
    {
        LoadImage(round.bgViewImageUrl);
    }

    public void InitUIBg(string url)
    {
        LoadImage(url);
    }
    
    private void LoadImage(string imageUrl)
    {
        if (_lostLoadedImage != imageUrl)
        {
            _bgSprite.sprite = ImageLoader.LoadSprite(imageUrl);
            _lostLoadedImage = imageUrl;
        }

        UpdateSize();
    }

    public bool haveControllingImage
    {
        get
        {
            return _bgSprite.sprite != null;
        }
    }

    private void UpdateSize()
    {
        _bgWidth = _bgSprite.bounds.size.x * _bgSprite.sprite.pixelsPerUnit;
        _bgHeight = _bgSprite.bounds.size.y * _bgSprite.sprite.pixelsPerUnit;
        _pixelPerUnit = _bgSprite.sprite.pixelsPerUnit;
        _size = _bgSprite.bounds.size;
        CameraNavigationManager.Instance.SetDefaultSettings();
    }

    public Vector3 bgSize
    {
        get
        {
            return _size;
        }
    }

    public float bgWidth
    {
        get
        {
            return _bgWidth;
        }
    }

    public float bgHeight
    {
        get
        {
            return _bgHeight;
        }
    }
    
    public float pixelPerUnit
    {
        get
        {
            return _pixelPerUnit;
        }
    }
}

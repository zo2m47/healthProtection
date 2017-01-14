using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System;
/**
Logic of view InfestedArea in ui
**/
public class InfestedAreaController : MonoBehaviour, IRecyle, ITouchCommand
{
    [SerializeField]
    private SpriteRenderer _spriteRenderer;
    
    [SerializeField]
    private GameObject _lockView;

    [SerializeField]
    private CircleCollider2D _circleCollider2D;

    private RoundVO _roundData;

    private bool _locked;

    
    public void Start()
    {
        if (_spriteRenderer == null)
        {
            LoggingManager.AddErrorToLog("_spriteRenderer in InfestedAreaController doesnt exist");
        }

        if (_lockView == null)
        {
            LoggingManager.AddErrorToLog("_lockImage in InfestedAreaController doesnt exist");
        }

        if (_circleCollider2D == null)
        {
            LoggingManager.AddErrorToLog("_circleCollider2D in InfestedAreaController doesnt exist");
        }
    }

    public void InitViewData(RoundVO roundData)
    {
        _roundData = roundData;
        _spriteRenderer.sprite = ImageLoader.LoadSprite(_roundData.infestedAreaViewImageUrl);
        _circleCollider2D.radius = _spriteRenderer.sprite.bounds.size.x / 2;
        CheckOnLock();
    }

    private void CheckOnLock()
    {
        _locked = GameModel.Instance.CheckOnPassed(_roundData.passedRoundsIds).Count == 0;
        _lockView.SetActive(!_locked);
    }
    
    /*
    releas IRecyle
    */
    public void Restart()
    {

        if (_roundData != null)
        {
            CheckOnLock();
        }
    }

    public void Shutdown()
    {
        
    }
    /*ITouchCommand
     * */
    public bool draggable
    {
        get
        {
            return false;
        }
    }

    public void TouchClick()
    {
        UIModel.Instance.mainMenuController.SelectRound(_roundData);
    }

    public void TouchMoved(Vector3 movedPosition)
    {
        
    }

    public void TouchStartDrag()
    {
        
    }

    public void TouchStopDrag()
    {
        
    }
}


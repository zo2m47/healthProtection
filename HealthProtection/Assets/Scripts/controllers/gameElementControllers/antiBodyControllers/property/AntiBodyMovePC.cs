using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* Logic of moving
* */
public class AntiBodyMovePC : AntiBodyBasePC
{
    protected bool _moving = false;
    private IEnumerator _stopCoroutine;

    protected override void InitDelegate()
    {
        base.InitDelegate();
        _gameController.stopAllDelegate += StopAllDelegate;
        _gameController.stopDelagate += StopDelegate;
        _gameController.moveDelagate += MovingDelegate;
        _gameController.restartDelegate += RestatDelegate;
    }

    /*Delegate methods 
     * */
    private void RestatDelegate()
    {
        _gameController.Move();
    }

    private void MovingDelegate()
    {
        _gameController.gameObject.transform.eulerAngles = new Vector3(0,0,_gameController.attackDirectionVO.rotation);
        _moving = true;
    }

    private void StopDelegate()
    {
        _moving = false;
    }

    private void StopAllDelegate()
    {
        _moving = false;
        //stop all delegate 
        if (_stopCoroutine != null)
        {
            StopCoroutine(_stopCoroutine);
        }
    }

    /* ligc of current property 
    * */
    public void Update()
    {
        if (_moving)
        {
            if (position == _gameController.attackDirectionVO.finishPosition)
            {
                _gameController.Die();
                return;
            }
            //move virus to core
            float moveSpeed = staticData.speed * Time.deltaTime;
            position = Vector3.MoveTowards(position, _gameController.attackDirectionVO.finishPosition, moveSpeed);
        }
    }

    private Vector3 position
    {
        get
        {
            return _gameController.gameObject.transform.position;
        }
        set
        {
            _gameController.gameObject.transform.position = value;
        }
    }
}

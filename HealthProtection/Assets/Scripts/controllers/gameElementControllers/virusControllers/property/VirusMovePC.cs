using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
 * logic of virus moving 
 * */
public class VirusMovePC : VirusBasePC
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
    private void MovingDelegate()
    {
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
        if (_stopCoroutine!=null)
        {
            StopCoroutine(_stopCoroutine);
        }
    }

    private void RestatDelegate()
    {
        _gameController.Move();
    }
    /* ligc of current property 
    * */
    public void Update()
    {
        if (_moving)
        {
            //move virus to core
            float moveSpeed = staticData.speed* Time.deltaTime;
            _gameController.gameObject.transform.position = Vector3.MoveTowards(position, GameController.Instance.corePosition, moveSpeed);
            //roitate virus to core
            var angle = Vector2.Angle(Vector2.right, GameController.Instance.corePosition - position);
            _gameController.gameObject.transform.eulerAngles = new Vector3(0f, 0f, position.y < GameController.Instance.corePosition.y ? angle : -angle);

        }
    }
    
    private Vector3 position
    {
        get
        {
            return _gameController.gameObject.transform.position;
        }
    }
    /* use frome outside
     * */
    //stop of the time 
    public void StopOfTheTime(int stopSecond)
    {
        if (_stopCoroutine!=null)
        {
            StopCoroutine(_stopCoroutine);
        }

        if (_moving)
        {
            _gameController.Stop();
        }

        _stopCoroutine = StopOfTheTimeEnumerator(stopSecond);
        StartCoroutine(_stopCoroutine);
    }

    private IEnumerator StopOfTheTimeEnumerator(int stopSeconds)
    {
        yield return new WaitForSeconds(stopSeconds);
        _gameController.Move();
        _stopCoroutine = null;
        yield break;
    }
}

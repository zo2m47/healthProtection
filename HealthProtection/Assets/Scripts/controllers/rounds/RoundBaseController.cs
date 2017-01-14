using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/**
* Logic of round 
* */
public class RoundBaseController : MonoBehaviour, IRoundGameController, IRecyle
{
    private RoundVO _roundStaticData;
    private IEnumerator _attackCounter;
    private int _attacksLeft;
    //where key is time when must start
    private Dictionary<int, List<AttackSettingVO>> _attack;
    private void RemoveGameElementDelegate()
    {

    }

    /* Game logic 
     * */
    private IEnumerator AttackCounter()
    {
        int roundSecond = 0;
        while (_attacksLeft>0)
        {
            if (_attack.ContainsKey(roundSecond))
            {
                for (int i = 0;i<_attack[roundSecond].Count;i++)
                {
                    PrefabVirusCreator.CreatVirusGameController(_attack[roundSecond][i].virusData, _attack[roundSecond][i].startPosition);
                    _attacksLeft--;
                }
            }

            AttackProgress();

            if (_attacksLeft <= 0)
            {
                AttacksFinish();
                yield break;
            }

            yield return new WaitForSeconds(1);
            roundSecond++;
        }
    }

    private void AttackProgress()
    {
        //TODO for view progress Debug.Log("attacks left "+ _attacksLeft);
    }
    
    private void AttacksFinish()
    {
        Debug.Log("Round finish");
    }

    // init attacks 
    private void InitAttacks()
    {
        _attack = new Dictionary<int, List<AttackSettingVO>>();
        _attacksLeft = 0;
        int attackTime;
        for (int i = 0; i < _roundStaticData.attackList.Count; i++)
        {
            for (int j = 0;j< _roundStaticData.attackList[i].counter; j++)
            {
                attackTime = Random.Range(_roundStaticData.attackList[i].start, _roundStaticData.attackList[i].end);
                if (!_attack.ContainsKey(attackTime))
                {
                    _attack.Add(attackTime, new List<AttackSettingVO>());
                }
                _attacksLeft++;
                _attack[attackTime].Add(new AttackSettingVO(_roundStaticData.attackList[i].virus));
            }
        }
    }
    /*IRoundGameController
     * */
    public void SetData(RoundVO data)
    {
        if (_attackCounter == null)
        {
            _attackCounter = AttackCounter();
        }
        _roundStaticData = data;
        InitAttacks();
    }
    
    public void StartRound()
    {
        StartCoroutine(_attackCounter);
    }
    /*IRecyle
     * */
    public void Restart()
    {
        GameController.Instance.removeAllGameElementsDelegate += RemoveGameElementDelegate;
    }

    public void Shutdown()
    {
        GameController.Instance.removeAllGameElementsDelegate -= RemoveGameElementDelegate;
        StopCoroutine(_attackCounter);
    }
}


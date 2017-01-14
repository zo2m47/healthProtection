using UnityEngine;
using System.Collections;
/**
 * game controller of antiBodies
 * */
public class AntiBodyBaseGameController : GameElementBaseController<AntiBodyVO>
{
    private AttackDirectionVO _attackDirectionVO;
    public AttackDirectionVO attackDirectionVO { get { return _attackDirectionVO; } }

    public void SetDirection(AttackDirectionVO lattackDirectionVO)
    {
        _attackDirectionVO = lattackDirectionVO;
    }
}

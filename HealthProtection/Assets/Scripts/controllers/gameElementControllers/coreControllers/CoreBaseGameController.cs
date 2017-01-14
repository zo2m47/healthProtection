using UnityEngine;
using System;
/**
* base game controller of CORE elemnt 
* */
public class CoreBaseGameController:GameElementBaseController<CoreVO>, ICoreGameController
{

    /*Overrided methods
     * */
    //damage 
    public override int damage
    {
        set
        {
            if (_dead)
            {
                return;
            }

            _damage += value;
            if (_damage>=health)
            {
                Die();
            }
        }

        get
        {
            return _damage;
        }
    }

    // need override this method in child classes
    public override int health
    {
        get
        {
            return _staticData.health;
        }
    }

    /*ICoreGameController
     * */
    public virtual void SetData(CoreVO data)
    {
        SetStaticData(data);
    }

    public virtual Vector3 corePosition
    {
        get
        {
            return gameObject.transform.position;
        }
    }

}

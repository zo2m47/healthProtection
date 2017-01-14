using UnityEngine;

public class DelegateController:MonoBehaviour
{
    public delegate void DelegateWithOneParametr(int value);
    public delegate void DelegateEmpty();
    // stop all coroutines
    public DelegateEmpty stopAllDelegate;
    //set static data
    public DelegateEmpty restartDelegate;
    //takce some damage frome 
    public DelegateWithOneParametr damageDelegate;
    //starts attack 
    public DelegateEmpty attackDelegate;
    //die 
    public DelegateEmpty dieDelagate;
    //start move 
    public DelegateEmpty moveDelagate;
    //stop move 
    public DelegateEmpty stopDelagate;

    /* Method work with delegates 
     * */
    public virtual void Damage(int value)
    {
        if (damageDelegate != null)
        {
            damageDelegate(value);
        }
    }

    public virtual void Attack()
    {
        if (attackDelegate != null)
        {
            attackDelegate();
        }
    }

    public virtual void Die()
    {
        if (dieDelagate != null)
        {
            dieDelagate();
        }
    }

    public virtual void Move()
    {
        if (moveDelagate != null)
        {
            moveDelagate();
        }
    }

    public virtual void Stop()
    {
        if (stopDelagate != null)
        {
            stopDelagate();
        }
    }

    public virtual void SopAll()
    {
        if (stopAllDelegate != null)
        {
            stopAllDelegate();
        }
    }
}

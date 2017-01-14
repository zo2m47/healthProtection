using UnityEngine;
using System.Collections;
/**
 * base game controller of game elements (viruses, core, antitode)
 * save current virus damage 
 * */
public class GameElementBaseController<S> : DelegateController, IRecyle
{
    //if game element is died 
    protected bool _dead = false;
    //damage of current game element
    protected int _damage = 0;
    //static data od current game element
    protected S _staticData;
    // Use this for initialization

    public virtual void SetStaticData(S data)
    {
        _staticData = data;
        Restart();
    }
    //return static data of current  game element 
    public S staticData
    {
        get
        {
            return _staticData;
        }
    }

    //damage 
    public virtual int damage
    {
        set
        {
            _damage += value;
        }

        get
        {
            return _damage;
        }
    }
    
    // need override this method in child classes
    public virtual int health
    {
        get
        {
            return 0;
        }
    }
    // remove this game object by delegate event
    private void RemoveGameElement()
    {
        PrefabCreatorManager.Instance.DestroyPrefab(gameObject);
    }
    /*IRecyle
     * */
    public virtual void Restart()
    {
        GameController.Instance.removeAllGameElementsDelegate += RemoveGameElement;
        _dead = false;
        _damage = 0;
        StartCoroutine(RestartCoroutine());
    }

    private IEnumerator RestartCoroutine()
    {
        yield return null;
        if (restartDelegate != null)
        {
            restartDelegate();
        }
    }

    public virtual void Shutdown()
    {
        GameController.Instance.removeAllGameElementsDelegate -= RemoveGameElement;
        SopAll();
    }

}

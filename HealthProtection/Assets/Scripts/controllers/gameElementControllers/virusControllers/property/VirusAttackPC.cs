using UnityEngine;
/**
* Virus attacking 
* */
public class VirusAttackPC : VirusBasePC
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        CoreDamagePC core = collision.GetComponent<CoreDamagePC>();
        if (core!=null)
        {
            core.SetDamage(_gameController.staticData.attack);
            //TODO just for testing 
            _gameController.Die();
        }
    }
}

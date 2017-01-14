using UnityEngine;
 /**
 * controller of attack 
 * */
public class AntiBodyAttackPC:AntiBodyBasePC
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        VirusDamagePC virus = collision.GetComponent<VirusDamagePC>();
        if (virus != null)
        {
            virus.SetDamage(_gameController.staticData.attack);
            //TODO just for testing 
            _gameController.Die();
        }
    }
}

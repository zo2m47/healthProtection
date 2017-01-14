/**
 * class with basse logic of damage outside
 * */
public class VirusDamagePC : VirusBasePC
{
    protected override void InitDelegate()
    {
        base.InitDelegate();
    }


    /* use frome outside
     * */
    //call from outside to set some damage 
    public void SetDamage(int damage)
    {
        _gameController.damage = damage;
    }

    //check on critical damage 
    public bool CheckOnCriticalDamage(int damage)
    {
        return _gameController.health < _gameController.damage + damage;
    }
}

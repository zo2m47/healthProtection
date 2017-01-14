/**
 * class with basse logic of damage outside
 * */
public class CoreDamagePC:CoreBasePC
{
    protected override void InitDelegate()
    {
        base.InitDelegate();
    }

    //call from outside to set some damage 
    public void SetDamage(int damage)
    {
        _gameController.damage = damage;
    }
}

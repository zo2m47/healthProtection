/**
 * Base game controller of virus 
 * */
public class VirusBaseGameController:GameElementBaseController<VirusVO>
{
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
            if (_damage >= health)
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
}

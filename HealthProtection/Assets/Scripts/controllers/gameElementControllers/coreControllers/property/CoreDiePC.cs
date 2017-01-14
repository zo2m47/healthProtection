/**
 * reaction of die
 * */
public class CoreDiePC:CoreBasePC
{
    protected override void InitDelegate()
    {
        base.InitDelegate();
        _gameController.dieDelagate += DieDelagate;
    }
    
    private void DieDelagate()
    {
        GameController.Instance.CoreDied();
    }
}

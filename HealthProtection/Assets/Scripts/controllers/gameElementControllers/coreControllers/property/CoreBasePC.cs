/**
 * base core propery controller
 * */
public class CoreBasePC : BasePropertyController<CoreBaseGameController,CoreVO>
{
    protected override string traceName { get { return "in CoreBasePropertyController " + staticData.id; } }
}

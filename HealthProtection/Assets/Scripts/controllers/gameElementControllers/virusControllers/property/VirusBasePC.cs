/**
 * base core propery controller
 * */
public class VirusBasePC : BasePropertyController<VirusBaseGameController,VirusVO>
{
    protected override string traceName { get { return "in VirusBasePropertyController " + staticData.id; } }
}

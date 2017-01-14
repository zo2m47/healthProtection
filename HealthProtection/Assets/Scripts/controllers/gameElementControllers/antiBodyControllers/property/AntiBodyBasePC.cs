/**
 * base antibody components controller 
 * */
public class AntiBodyBasePC:BasePropertyController<AntiBodyBaseGameController,AntiBodyVO>
{
    protected override string traceName { get { return "in AntiBodyBasePropertyController " + staticData.id; } }
}

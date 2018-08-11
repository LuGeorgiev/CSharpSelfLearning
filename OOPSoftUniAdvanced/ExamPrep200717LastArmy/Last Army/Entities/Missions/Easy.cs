

public class Easy : Mission
{
    private const string name = "Suppression of civil rebellion";
    private const double enduranceRequired = 20;
    private const double wareLevelDecrement = 30;
    public override string Name => name;

    public override double EnduranceRequired => enduranceRequired;    

    public override double WearLevelDecrement => wareLevelDecrement;

    public Easy(double scoreToComplete)
        :base(scoreToComplete)
    {
    }
}



class Medium:Mission
{
    private const string name = "Capturing dangerous criminals";
    private const double enduranceRequired = 50;
    private const double wareLevelDecrement = 50;
    public override string Name => name;

    public override double EnduranceRequired => enduranceRequired;

    public override double WearLevelDecrement => wareLevelDecrement;

    public Medium(double scoreToComplete)
        : base(scoreToComplete)
    {
    }
}


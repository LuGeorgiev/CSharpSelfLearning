

class Hard:Mission
{
    private const string name = "Disposal of terrorists";
    private const double enduranceRequired = 80;
    private const double wareLevelDecrement = 70;
    public override string Name => name;

    public override double EnduranceRequired => enduranceRequired;

    public override double WearLevelDecrement => wareLevelDecrement;

    public Hard(double scoreToComplete)
        : base(scoreToComplete)
    {
    }
}


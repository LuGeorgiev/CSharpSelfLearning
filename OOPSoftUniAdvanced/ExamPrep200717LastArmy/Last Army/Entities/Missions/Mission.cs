

public abstract class Mission : IMission
{
    public abstract string Name { get; }

    public abstract double EnduranceRequired { get; }

    public double ScoreToComplete {get;}

    public abstract double WearLevelDecrement { get; }

    public Mission(double scoreToComplete)
    {
        ScoreToComplete = scoreToComplete;
    }
}


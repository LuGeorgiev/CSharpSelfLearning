using System;

public abstract class Provider : IProvider
{
    private const double InitialDurability = 1000;
    private double energyOutput;
    private const double DurabilityLossPerDay = 100;

    private double durability;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.Durability = InitialDurability;
        this.EnergyOutput = energyOutput;
    }

    public double EnergyOutput { get; protected set; }

    public int ID { get; }

    public double Durability
    {
        get
        {
            return this.durability;
        }
        protected set
        {
            if (value<0)
            {
                throw new ArgumentException(string.Format(Constants.ProviderBroken, this.GetType().Name));
            }
            this.durability = value;
        }
    }

    public void Broke()
    {
        this.Durability -=DurabilityLossPerDay;
    }

    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        return this.GetType().Name + Environment.NewLine + $"Durability: {this.Durability}";
    }

}
using System;

public class InfinityHarvester : Harvester
{
    private const int OreOutputDivider = 10;
    private const int ForeverYoung = 10000;

    private double durability;

    public InfinityHarvester(int id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput /= OreOutputDivider;
    }

    public override double Durability
    {
        get => this.durability;
        protected set => this.durability = ForeverYoung;
    }
}
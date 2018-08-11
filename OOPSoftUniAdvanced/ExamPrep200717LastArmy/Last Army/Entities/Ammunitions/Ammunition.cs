using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public abstract class Ammunition : IAmmunition
{
    private const int wareLevelMultiplyer = 100;
    public Ammunition()
    {
        this.WearLevel = Weight * wareLevelMultiplyer;
    }
    public string Name => this.GetType().Name; // will return the name of the instance that inherits this class. cannot return Amunition.Name (abstarct)

    public abstract double Weight { get; }

    public double WearLevel { get; private set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }
}


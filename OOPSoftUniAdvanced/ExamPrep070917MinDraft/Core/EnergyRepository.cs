using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class EnergyRepository : IEnergyRepository
{    

    public double EnergyStored { get; private set;}

    public void StoreEnergy(double energy)
    {
        this.EnergyStored += energy;
    }

    public bool TakeEnergy(double energyNeeded)
    {
        bool isEnergyEnought = true;

        if (this.EnergyStored<energyNeeded)
        {
            isEnergyEnought= false;
        }
        else
        {
            this.EnergyStored -= energyNeeded;
        }

        return isEnergyEnought;
    }
}



using System.Collections.Generic;
using System.Linq;

public class WareHouse : IWareHouse
{
    private Dictionary<string, int> ammunitionQuantities;
    private IAmmunitionFactory ammunitionFactory;
    public WareHouse()
    {
        ammunitionQuantities = new Dictionary<string, int>();
        ammunitionFactory = new AmmunitionFactory();
    }

    public void AddAmmmunition(string ammunition, int quantities)
    {
        if (ammunitionQuantities.ContainsKey(ammunition))
        {
            ammunitionQuantities[ammunition] += quantities;
        }
        else
        {
            ammunitionQuantities.Add(ammunition, quantities);
        }
    }

    public void EquipArmy(IArmy army)
    {
        foreach (var soldier in army.Soldiers)
        {
            TryEquipSoldier(soldier);
        }
    }
    public bool TryEquipSoldier(ISoldier soldier)
    {
        var wornOutWeapons = soldier.Weapons.Where(w => w.Value == null)
            .Select(w=>w.Key)
            .ToList();
        bool isSoldieEquipped = true;

        foreach (var weapon in wornOutWeapons)
        {
            if (ammunitionQuantities.ContainsKey(weapon) &&
                ammunitionQuantities[weapon]>0) 
            {
                soldier.Weapons[weapon] = ammunitionFactory.CreateAmmunition(weapon);
                ammunitionQuantities[weapon]--;
            }
            else
            {
                isSoldieEquipped = false;
            }
        }

        return isSoldieEquipped;
    }
}


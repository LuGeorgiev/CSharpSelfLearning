using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Corporal:Soldier
{
    private const double overallSkillMiltiplier = 2.5;

    protected override double OverallSkillMultiplayer => overallSkillMiltiplier;
    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(Helmet),
        nameof(Knife),
        nameof(MachineGun),
    };

    protected override List<string> WeaponsAllowed => weaponsAllowed;

    public Corporal(string name, int age, double experience, double endurance)
         : base(name, age, experience, endurance)
    {
    }
}


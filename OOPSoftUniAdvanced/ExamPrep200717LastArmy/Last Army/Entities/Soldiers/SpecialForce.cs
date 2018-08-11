using System.Collections.Generic;
using System.Text;

 public class SpecialForce : Soldier
 {
    private const double overallSkillMiltiplier = 3.5;
    private const int regenerateIncrease = 30;
    protected override double OverallSkillMultiplayer => overallSkillMiltiplier;
    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),
        nameof(MachineGun),
        nameof(RPG),
        nameof(Helmet),
        nameof(Knife),
        nameof(NightVision)
    };

    protected override List<string> WeaponsAllowed => weaponsAllowed;
    protected override int RegenerateIncrease => regenerateIncrease;
    public SpecialForce(string name, int age, double experience, double endurance)
         : base(name, age, experience, endurance)
     {
     }
 }

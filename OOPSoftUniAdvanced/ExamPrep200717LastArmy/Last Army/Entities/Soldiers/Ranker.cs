using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class Ranker : Soldier
{
    private const double overallSkillMiltiplier = 1.5;
    
    protected override double OverallSkillMultiplayer => overallSkillMiltiplier;
    private readonly List<string> weaponsAllowed = new List<string>
    {
        nameof(Gun),
        nameof(AutomaticMachine),       
        nameof(Helmet)        
    };

    protected override List<string> WeaponsAllowed => weaponsAllowed;
    
    public Ranker(string name, int age, double experience, double endurance)
         : base(name, age, experience, endurance)
    {
    }
}


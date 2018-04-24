using P08_MilitaryElite.Soldiers;
using P08_MilitaryElite.Soldiers.Utilities;
using System;

namespace P08_MilitaryElite
{
    public class StartUp
    {
        static void Main()
        {
            var commando = new Commando("12313","Ivan","Peshov",2.34, "Marnes");
            
            commando.AddMission(new Mission("slay", "inProgress"));
            commando.AddMission(new Mission("fight", "failed"));

            Console.WriteLine(commando);
        }
    }
}

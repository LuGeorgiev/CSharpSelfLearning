using P08_MilitaryElite.Interfaces;
using P08_MilitaryElite.Interfaces.IUtilities;
using P08_MilitaryElite.Soldiers.Utilities;
using System;
using System.Collections.Generic;
using System.Text;

namespace P08_MilitaryElite.Soldiers
{
    class Commando : SpecialisedSoldier,ICommando
    {
        public List<IMission> Missions { get; private set; }
        public Commando(string id, string firstName, string lastName, double salary, string soldierCorps) 
            : base(id, firstName, lastName, salary, soldierCorps)
        {
            this.Missions = new List<IMission>();
        }

        public void AddMission(IMission mission)
        {
            if (mission.MissionStatus==(Status)2)
            {
                return;
            }
            this.Missions.Add(mission);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine(base.ToString());
            sb.AppendLine("Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine($"  {mission.ToString()}");
            }

            return sb.ToString().TrimEnd();
        }

    }
}

using P08_MilitaryElite.Interfaces;
using P08_MilitaryElite.Interfaces.IUtilities;
using P08_MilitaryElite.Soldiers.Utilities;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System;

namespace P08_MilitaryElite.Soldiers
{
    class Commando : SpecialisedSoldier,ICommando
    {
        private ICollection<IMission> missions;
        public IReadOnlyCollection<IMission> Missions
        {
            get
            {
                return (IReadOnlyCollection<IMission>)this.missions;
            }
        }
        public Commando(int id, string firstName, string lastName, double salary, string soldierCorps) 
            : base(id, firstName, lastName, salary, soldierCorps)
        {
            this.missions = new List<IMission>();
        }

        public void AddMission(IMission mission)
        {            
            this.missions.Add(mission);
        }
        public void CompleteMission(string missionCodeName)
        {
            IMission mission = this.Missions
                .FirstOrDefault(x => x.MissionName == missionCodeName);
            if (mission==null)
            {
                throw new ArgumentException("mission not found");
            }
            mission.CompleteMission();
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

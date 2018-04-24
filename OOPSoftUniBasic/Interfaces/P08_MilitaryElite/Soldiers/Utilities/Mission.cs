using P08_MilitaryElite.Interfaces.IUtilities;
using System;


namespace P08_MilitaryElite.Soldiers.Utilities
{
    public enum Status { inProgress, Finished, Invalid};

    public class Mission: IMission
    {
        public string MissionName { get; private set; }
        public Status MissionStatus { get; private set; }

        public Mission(string missionName, string missionStatus)
        {
            this.MissionName = missionName;
            try
            {
                this.MissionStatus = (Status)Enum.Parse(typeof(Status), missionStatus);
            }
            catch (Exception)
            {
                this.MissionStatus = (Status)2;
            }                    
            
        }

        public void CompleteMission()
        {
            this.MissionStatus = (Status)1;
        }

        public override string ToString()
        {
            return $"  Code Name: {this.MissionName} State: {this.MissionStatus.ToString()}";
        }
    }
}

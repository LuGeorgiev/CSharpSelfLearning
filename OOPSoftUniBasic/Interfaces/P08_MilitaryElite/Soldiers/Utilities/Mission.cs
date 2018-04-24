using P08_MilitaryElite.Interfaces.IUtilities;
using System;


namespace P08_MilitaryElite.Soldiers.Utilities
{
    public enum Status { inProgress, Finished};

    public class Mission: IMission
    {
        public string MissionName { get; private set; }
        public Status MissionStatus { get; private set; }

        public Mission(string missionName, string missionStatus)
        {
            this.MissionName = missionName;
            ParseMissionStatus(missionStatus);                   
            
        }

        private void ParseMissionStatus(string missionStatus)
        {
            bool validStatus = Enum.TryParse(typeof(Status), missionStatus, out object status);
            if (validStatus)
            {
                this.MissionStatus = (Status)status;
            }
            else
            {
                throw new ArgumentException("Invalid mission Status!");
            }
        }

        public void CompleteMission()
        {
            this.MissionStatus = Status.Finished;
        }

        public override string ToString()
        {
            return $"  Code Name: {this.MissionName} State: {this.MissionStatus.ToString()}";
        }
    }
}

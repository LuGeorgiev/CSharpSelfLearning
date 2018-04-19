using System;
using System.Collections.Generic;
using System.Text;

namespace P06_FutballTeamGenerator
{
    class Player
    {
        private string name;
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;

        public int AvgStats { get; private set; }
        public string Name
        {
            get { return name; }
            private set
            {
                if (value.Length==0||value==null||value.Contains(" "))
                {
                    throw new ArgumentException("A name should not be empty.");
                }
                name = value;
            }
        }
        public int Shooting
        {
            get { return shooting; }
            private set
            {
                IsValid(value, "Shooting");
                shooting = value;
            }
        }
        public int Passing
        {
            get { return passing; }
            private set
            {
                IsValid(value, "Passing");
                passing = value;
            }
        }
        public int Dribble
        {
            get { return dribble; }
            private set
            {
                IsValid(value, "Dribble");
                dribble = value;
            }
        }
        public int Sprint
        {
            get { return sprint; }
            private set
            {
                IsValid(value, "Sprint");
                sprint = value;
            }
        }
        public int Endurance
        {
            get { return endurance; }
            private set
            {
                IsValid(value,"Endurance");                
                endurance = value;
            }
        }

        public Player(string name, int endurance, int sprint, int dribble, int passing, int shooting)
        {
            Name = name;
            Endurance = endurance;
            Sprint = sprint;
            Dribble = dribble;
            Passing = passing;
            Shooting = shooting;

            AvgStats = CalculateAverage();
        }

        private int CalculateAverage()
        {
            //or Math.Truncate for int part only
            return (int)Math.Round((Endurance + Sprint + Dribble + passing + Shooting) / 5.0);
        }

        private void IsValid(int value, string stat)
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException($"{stat} should be between 0 and 100.");
            }
        }
    }
}

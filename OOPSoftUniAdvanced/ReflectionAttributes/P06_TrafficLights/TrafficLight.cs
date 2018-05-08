using P06_TrafficLights.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace P06_TrafficLights
{
    public class TrafficLight
    {
        public TrafficLight(string light )
        {
            this.Light = ParseLight(light);            
        }

        public TrafficColors Light { get; private set; }
        

        private TrafficColors ParseLight(string color)
        {
            bool isValidLight = Enum.TryParse(typeof(TrafficColors), color, true, out object result);
            if (!isValidLight)
            {
                throw new ArgumentException("Traffic color is not valid!");
            }

            return (TrafficColors)result;
        }

        public void ChangeLights()
        {
            this.Light = (TrafficColors)(((int)this.Light+1) % 3);           
        }

        public override string ToString()
        {
            return $"{this.Light} ";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Room
    {
        public List<Patient> PatientsInRoom { get; private set; }
        public Room()
        {
            this.PatientsInRoom = new List<Patient>();
        }
    }
}

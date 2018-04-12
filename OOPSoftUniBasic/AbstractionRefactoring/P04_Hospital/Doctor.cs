using System;
using System.Collections.Generic;
using System.Text;

namespace P04_Hospital
{
    class Doctor
    {
        public string Name { get; private set; }
        public List<Patient> Patients { get; private set; }

        public Doctor(string name)
        {
            this.Name = name;
            this.Patients = new List<Patient>();
        }

        public void AddPatient(string name)
        {
            this.Patients.Add(new Patient(name));
        }
    }
}

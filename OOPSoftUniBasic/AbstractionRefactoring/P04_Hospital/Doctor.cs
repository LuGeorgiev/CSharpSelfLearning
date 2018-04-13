using System;
using System.Collections.Generic;
using System.Linq;
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

        public void PrintPatiets()
        {
            var sortedPatients = this.Patients
                .OrderBy(x => x.Name);

            foreach (var patient in sortedPatients)
            {
                Console.WriteLine(patient.Name);
            }
                
        }
    }
}

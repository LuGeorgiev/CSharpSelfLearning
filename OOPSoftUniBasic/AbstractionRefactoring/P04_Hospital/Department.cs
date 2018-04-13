using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P04_Hospital
{
    class Department
    {
        public string departmentName { get; private set; }
        public int patientCount { get; private set; } = 0;
        public List<Room> Rooms { get; private set; }

        public Department(string name)
        {
            this.departmentName = name;
            this.Rooms = new List<Room>();
            for (int roomCount = 0; roomCount < 20; roomCount++)
            {
                this.Rooms.Add(new Room());
            }
        }

        public void AddPatient(string name)
        {
            if (this.patientCount<19)
            {
                int numberOfRoom = this.patientCount / 3;

                Rooms[numberOfRoom].PatientsInRoom.Add(new Patient(name));
                this.patientCount++;
            }
        }

        public void PrintPatients()
        {
            var patientsInDepartment = new List<Patient>();
            
            foreach (var room in this.Rooms)
            {
                if (room.PatientsInRoom.Count>0)
                {
                    foreach (var patient in room.PatientsInRoom)
                    {
                        patientsInDepartment.Add(patient);
                    }
                }
            }

            patientsInDepartment                
                .ForEach(x => Console.WriteLine(x.Name));
        }

        public void PrintPatientInRoom(int room)
        {
            if (0<=room&&room<=19)
            {
                var roomFound = this.Rooms[room].PatientsInRoom
                    .OrderBy(x=>x.Name);
                foreach (var patient in roomFound)
                {
                    Console.WriteLine(patient.Name);
                }

            }
                
        }
        
    }
}

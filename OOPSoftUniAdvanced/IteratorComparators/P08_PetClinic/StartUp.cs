using System;
using System.Linq;
using System.Collections.Generic;

namespace P08_PetClinic
{
    public class StartUp
    {
        static void Main()
        {
            List<Pet> pets = new List<Pet>();
            List<PetClinic> clinics = new List<PetClinic>();

            int commandCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < commandCount; i++)
            {
                string[] commandIntput = Console.ReadLine().Split();
                string command = commandIntput[0];

                if (command == "Create")
                {
                    try
                    {
                        string typeOfCreation = commandIntput[1];
                        if (typeOfCreation == "Pet")
                        {
                            var name = commandIntput[2];
                            int age = int.Parse(commandIntput[3]);
                            var kind = commandIntput[4];
                            var pet = new Pet(name, age, kind);

                            pets.Add(pet);
                        }
                        else
                        {
                            int roomCount = int.Parse(commandIntput[3]);
                            PetClinic clinic = new PetClinic(roomCount, commandIntput[2]);
                            clinics.Add(clinic);
                        }
                    }
                    catch (InvalidOperationException ex)
                    {
                        Console.WriteLine(ex.Message);
                    }   
                }
                else if (command == "Add")
                {
                    Pet pet = pets.FirstOrDefault(x => x.Name == commandIntput[1]);
                    PetClinic clinic = clinics.FirstOrDefault(c => c.Name == commandIntput[2]);
                    Console.WriteLine(clinic.Add(pet)); 
                }
                else if (command == "Release")
                {
                    PetClinic clinic = clinics.FirstOrDefault(c => c.Name == commandIntput[1]);
                    Console.WriteLine(clinic.Release()); 
                }
                else if (command == "HasEmptyRooms")
                {
                    PetClinic clinic = clinics.FirstOrDefault(c => c.Name == commandIntput[1]);
                    Console.WriteLine(clinic.HasEmptyRooms);
                }
                else if (command == "Print")
                {
                    PetClinic clinic = clinics.FirstOrDefault(c => c.Name == commandIntput[2]);
                    if (commandIntput.Length==3)
                    {
                        int roomToPrint = int.Parse(commandIntput[2]);
                        Console.WriteLine(clinic.Print(roomToPrint));
                        clinic.Print(roomToPrint);
                    }
                    else
                    {                        
                        Console.WriteLine(clinic.PrintAll());
                    }
                }                
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Google
{
    class Person
    {        
        public string CompanyName { get; private set; }
        public string Department { get; private set; }
        public string Salary { get; private set; }
        public string CarModel { get; private set; }
        public string CarSpeed { get; private set; }

        public List<Pokemon> Pokemons { get; private set; }
        public List<Child> Children { get; private set; }
        public List<Parent> Parents { get; private set; }


        public Person()
        {
            this.Pokemons = new List<Pokemon>();
            this.Children = new List<Child>();
            this.Parents = new List<Parent>();
        }

        public void AddPokemon(Pokemon newPokemon)
        {
            this.Pokemons.Add(newPokemon);
        }

        public void AddChild(Child anotherChild)
        {
            this.Children.Add(anotherChild);
        }

        public void AddParent(Parent parentFound)
        {
            this.Parents.Add(parentFound);
        }

        public void SetCar(string model, string speed)
        {
            this.CarModel = model;
            this.CarSpeed = speed;
        }

        public void SetCompany(string companuName, string department, string salary)
        {
            this.CompanyName = companuName;
            this.Department = department;
            this.Salary = salary;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();            
            builder.AppendLine("Company:");     
            
            if (this.CompanyName!=null)
            {
                builder.AppendLine(this.CompanyName + " " + this.Department + " " + this.Salary);             

            }
            builder.AppendLine("Car:");            
            if (this.CarModel != null)
            {
                builder.AppendLine(this.CarModel + " " + this.CarSpeed );               
            }
            
            builder.AppendLine("Pokemon:");            
            foreach (var pokemon in this.Pokemons)
            {
                builder.AppendLine(pokemon.Name + " " + pokemon.Type);                
            }
            builder.AppendLine("Parents:");            
            foreach (var parent in this.Parents)
            {
                builder.AppendLine(parent.Name + " " + parent.BirthDate);                
            }
            builder.AppendLine("Children:");            
            foreach (var child in this.Children)
            {
                builder.AppendLine(child.Name + " " + child.BirtDate);                
            }
            return builder.ToString();
        }

        
    }
}

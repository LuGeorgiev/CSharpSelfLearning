using System;
using System.Collections.Generic;
using System.Linq;


namespace LectureDemo
{
    class Demo
    {
        static void Main(string[] args)
        {
            var people = new List<Person>();

            var dictionaryPeople = people.ToDictionary(p => p.Name);

            var name = "Ivan";
            var person = dictionaryPeople[name];
            var ageAndName = people.Select(p => new {PesonAge=p.Age,PersonName=p.Name });//anonymous class
            foreach (var p in ageAndName)
            {
                //this way only a part of the properties can be used by teh anonymous class
            }
            
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person()
        {

        }
        public Person(string name):this()
        {
            this.Name = name;
        }
        public Person(string name, int age):this(name)
        {
            this.Age = age;   
        }
    }
}

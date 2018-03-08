using System;


namespace lecture
{
    class lectureFirst
    {
        static void Main(string[] args)
        {
            //var blue = "Blue";
            //var enumValue = Enum.Parse(typeof(FeathersColor), blue);
            //Console.WriteLine(enumValue);

            var kolibri = new Kolibri("Penchev", FeathersColor.Green,1);
            kolibri.Introduce();           
        }
    }

    public class Kolibri
    {
        private FeathersColor feathersColor;
        private string name;
        private int age;

        
        public Kolibri(string name, FeathersColor feathersColor, int age)
        {
            this.name = name;
            this.feathersColor = feathersColor;
            this.age = age;
        }
        
        public void Introduce()
        {
            Console.WriteLine($"Mu name is {this.name} I am {this.age} years old and I have {this.feathersColor} feathers");
        }
        
        
    }

    public enum FeathersColor
    {
        Red, Green, Blue, Mixed  
    }
}

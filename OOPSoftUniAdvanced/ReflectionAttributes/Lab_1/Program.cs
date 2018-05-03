using System;

namespace Lab_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(TestReflection);
            Console.WriteLine(type.Name);

            var interfaces = type.GetInterfaces();

            // Can creat instances via constructors
            var tr = Activator.CreateInstance(typeof(TestReflection)); //cannot make instances from private
        }
    }
}

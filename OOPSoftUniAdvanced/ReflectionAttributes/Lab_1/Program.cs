using System;
using System.Reflection;

namespace Lab_1
{
    public class Program
    {
        static void Main(string[] args)
        {
            var type = typeof(System.Text.StringBuilder);
            Console.WriteLine(type.Name);

            var interfaces = type.GetInterfaces();

            // Can creat instances via constructors
            var rt = Activator.CreateInstance(typeof(TestReflection)); //cannot make instances from private

            var sb = Activator.CreateInstance(Type.GetType("System.Text.StringBuilder"));
            ((System.Text.StringBuilder)sb).Append("Test");

            var typeField = typeof(Lab_1.TestReflection);
            var fields = typeField.GetFields(BindingFlags.Static|BindingFlags.Public
                |BindingFlags.NonPublic|BindingFlags.Instance);
            var field = typeField.GetField("privateInstance");

            var constructor = type.GetConstructor(new Type[] { typeof(int), typeof(int) });
            var sbNew = constructor.Invoke(new object[] { 5, 1000 });

            var appendMethod = type.GetMethod("Append", new Type[] { typeof(string) }); // define the exact method overload
            appendMethod.Invoke(sbNew, new object[] { "appendMethod called" });
        }
    }
}

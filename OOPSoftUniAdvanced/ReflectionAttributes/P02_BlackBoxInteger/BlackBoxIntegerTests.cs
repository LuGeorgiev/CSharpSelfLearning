namespace P02_BlackBoxInteger
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class BlackBoxIntegerTests
    {
        public static void Main()
        {
            var classType = Type.GetType("P02_BlackBoxInteger.BlackBoxInteger");
            var classMethods = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);

            //var constructor = classType.GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance, null, new Type[0], null);
            //var instance = (BlackBoxInteger)constructor.Invoke(null);

            // Second. Easier way
            var instance = Activator.CreateInstance(classType, true);
            var field = classType.GetField("innerValue", BindingFlags.NonPublic | BindingFlags.Instance);

            var input = "";
            while ((input=Console.ReadLine())!="END")
            {
                string[] tokens = input.Split('_');
                string command = tokens[0];
                int number = int.Parse(tokens[1]);

                MethodInfo method = classMethods.FirstOrDefault(m => m.Name == command);
                method.Invoke(instance, new object[] { number});
                Console.WriteLine(field.GetValue(instance));
            }        
                

        }
    }
}

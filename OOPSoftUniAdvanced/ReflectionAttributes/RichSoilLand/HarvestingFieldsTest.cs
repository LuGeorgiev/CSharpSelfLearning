 namespace P01_HarvestingFields
{
    using System;
    using System.Linq;
    using System.Reflection;

    public class HarvestingFieldsTest
    {
        public static void Main()
        {
            var input = "";
            var classType = typeof(HarvestingFields);

            while ((input=Console.ReadLine())!= "HARVEST")
            {
                var fielsOfInvestigated = classType.GetFields(BindingFlags.NonPublic
                    |BindingFlags.Instance|BindingFlags.Public);
                foreach (var field in fielsOfInvestigated)
                {
                    if (field.IsPrivate && input == "private")
                    {
                        PrintFields("private", field);
                    }
                    else if (field.IsPublic && input == "public")
                    {
                        PrintFields("public", field);
                    }
                    else if (field.IsFamily&& input == "protected")
                    {
                        PrintFields("protected", field);
                    }
                    else if (input == "all")
                    {
                        //TODO
                        PrintFields(field);
                    }
                }
                
            }
        }

        private static void PrintFields(FieldInfo field)
        {
            var accessModifier = "";
            if (field.Attributes.ToString()=="Family")
            {
                accessModifier = "protected";
            }
            else
            {
                accessModifier = field.Attributes.ToString().ToLower();
            }

            string fieldType = field.FieldType
                .ToString()
                .Split('.')
                .LastOrDefault();
            Console.WriteLine($"{accessModifier} {fieldType} {field.Name}");
        }

        private static void PrintFields(string accesModifier, FieldInfo field)
        {
            string fieldType = field.FieldType
                .ToString()
                .Split('.')
                .LastOrDefault();

            Console.WriteLine($"{accesModifier} {fieldType} {field.Name}");
        }
    }
}

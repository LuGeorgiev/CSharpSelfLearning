using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace LabSpy
{
    [SoftUni("Pesho")]
    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] fieldsToInvestigate)
        {
            Type classType = Type.GetType("LabSpy."+classToInvestigate);
            var sb = new StringBuilder($"Class under investigation: {classToInvestigate}"+Environment.NewLine);

            Object classInstance = Activator.CreateInstance(classType, new object[] {});

            FieldInfo[] fields = classType
                .GetFields(BindingFlags.Instance | BindingFlags.Public| BindingFlags.NonPublic|BindingFlags.Static);


            foreach (FieldInfo field in fields)
            {
                if (fieldsToInvestigate.Contains(field.Name))
                {
                    sb.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
                }
            }
            return sb.ToString().TrimEnd();
        }

        public string  AnalyzeAcessModifiers(string className)
        {
            Type classType = Type.GetType("LabSpy." + className);
            var sb = new StringBuilder();

            FieldInfo[] classFields= classType.GetFields();
            MethodInfo[] classPublicMethods = classType.GetMethods(BindingFlags.Public|BindingFlags.Instance);
            MethodInfo[] classPrivateMethods = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Instance);

            foreach (var field in classFields)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in classPrivateMethods)
            {
                if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} have to be public!");
                }
            }
            foreach (var method in classPublicMethods)
            {
                if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} have to be private!");
                }                
            }
            return sb.ToString().Trim();
        }

        public string RevealPrivateMethods(string className)
        {
            var sb = new StringBuilder($"All Private Methods of Class: {className}"+Environment.NewLine);

            var classType = Type.GetType("LabSpy." + className);       
            var privateMethods = classType.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Static);

            sb.AppendLine($"Base Class: {classType.BaseType.Name}");
            foreach (var method in privateMethods)
            {
                sb.AppendLine(method.Name);
            }

            return sb.ToString().Trim();
        }

        public string CollectGettersAndSetters(string classToInvestigate)
        {
            var sb = new StringBuilder();
            Type classType = Type.GetType($"LabSpy." + classToInvestigate);
            MethodInfo[] classMethods = classType.GetMethods(BindingFlags.NonPublic|BindingFlags.Public|BindingFlags.Instance);

            foreach (var method in classMethods)
            {
                if (method.Name.StartsWith("set"))
                {
                    sb.AppendLine($"{method.Name} will set field of {method.GetParameters().First().ParameterType}");
                }
                else if (method.Name.StartsWith("get"))
                {
                    sb.AppendLine($"{method.Name} will return {method.ReturnType}");
                }
            }

            return sb.ToString().Trim();
        }
    }
}

using P07_InfernoInfinity.Contracts;
using System;
using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace P07_InfernoInfinity.Core.Factories
{
    public class JemFactory : IJemFactory
    {
        public IJem CreateJem(string jemType, string jemClarity)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(x => x.Name == jemType);
            if (model==null)
            {
                throw new ArgumentException("Jem Type is not correct!");
            }
            if (!typeof(IJem).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{jemType} is unknown Jem Type");
            }
            object jem = Activator.CreateInstance(model, new object[] { jemClarity });

            return (IJem)jem;
        }
    }
}

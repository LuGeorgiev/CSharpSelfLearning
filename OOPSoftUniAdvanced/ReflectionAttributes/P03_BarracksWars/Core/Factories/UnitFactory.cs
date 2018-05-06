namespace _03BarracksFactory.Core.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;
    using Contracts;

    public class UnitFactory : IUnitFactory
    {
        public IUnit CreateUnit(string unitType)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type model = assembly.GetTypes().FirstOrDefault(t =>t.Name==unitType);

            if (model==null)
            {
                throw new ArgumentException("Invalid unit type");
            }

            //if (model.GetInterfaces().Any(i=>i==typeof(IUnit)))
            //Same thing another approach:
            if(!typeof(IUnit).IsAssignableFrom(model))
            {
                throw new ArgumentException($"{unitType} is Not a Unit Type");
            }
            IUnit unit = (IUnit)Activator.CreateInstance(model);

            return unit;


            //If we skip all checks up the whole code can be:
            return (IUnit)Activator
                .CreateInstance(
                Assembly.GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name == unitType));
        }
    }
}

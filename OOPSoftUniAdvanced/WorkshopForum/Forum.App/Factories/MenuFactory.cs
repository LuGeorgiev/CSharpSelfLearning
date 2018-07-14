using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forum.App.Factories
{
    class MenuFactory : IMenuFactory
    {
        private IServiceProvider serviceProvider;
        public MenuFactory(IServiceProvider serviceProvider)
        {
            this.serviceProvider = serviceProvider;
        }

        public IMenu CreateMenu(string menuName)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            Type menuType = assembly
                .GetTypes()
                .FirstOrDefault(x => x.Name.Equals($"{menuName}Menu", StringComparison.InvariantCultureIgnoreCase));
            if (menuType==null)
            {
                throw new InvalidProgramException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not a menu!");
            }

            ParameterInfo[] ctorParams = menuType
                .GetConstructors()
                .First()
                .GetParameters();
            object[] args = new object[ctorParams.Length];
            for (int i = 0; i < args.Length; i++)
            {
                args[i] = this.serviceProvider.GetService(ctorParams[i].ParameterType);
            }

            var menu = Activator.CreateInstance(menuType, args);

            return (IMenu)menu;
        }
    }
}

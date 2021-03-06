﻿using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Forum.App.Factories
{
    public class MenuFactory : IMenuFactory
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
                .FirstOrDefault(x => x.Name.Equals($"{menuName}", StringComparison.InvariantCultureIgnoreCase)); //TODO is adding Menu needed
            if (menuType==null)
            {
                throw new ArgumentException("Menu not found!");
            }

            if (!typeof(IMenu).IsAssignableFrom(menuType))
            {
                throw new InvalidOperationException($"{menuName} is not an IMenu!");
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

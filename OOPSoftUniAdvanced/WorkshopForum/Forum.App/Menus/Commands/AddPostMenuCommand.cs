﻿using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    class AddPostMenuCommand : NavigationCommand
    {
        private IMenuFactory menuFactory;

        public AddPostMenuCommand(IMenuFactory menuFactory)
            :base(menuFactory)
        {           
        }
        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            return menu;
        }
    }
}

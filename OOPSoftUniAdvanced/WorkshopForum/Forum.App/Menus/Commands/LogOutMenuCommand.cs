﻿using Forum.App.Contracts;
using System;


namespace Forum.App.Menus.Commands
{
    class LogOutMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory menuFactory;

        public LogOutMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            this.session.Reset();
            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}

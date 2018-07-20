using System;
using System.Collections.Generic;
using System.Text;
using Forum.App.Contracts;

namespace Forum.App.Menus.Commands
{
    //CRUSHED HERE
    public class LogInMenuCommand : ICommand
    {
        //private ISession session;
        private IMenuFactory menuFactory;
        //private IUserService userService;

        public LogInMenuCommand(IMenuFactory menuFactory, IUserService userService)
        {
            //this.session = session;
            this.menuFactory = menuFactory;
            //this.userService = userService;
        }
       

        public IMenu Execute(params string[] args)
        {
            //string username = args[0];
            //string password = args[1];
            //bool validUsername = !string.IsNullOrEmpty(username) && username.Length >= 4;
            //bool validPassword = !string.IsNullOrEmpty(password) && password.Length >= 4;
            //if (!validPassword||!validUsername)
            //{
            //    throw new ArgumentException("Invalid username or password");
            //}
            //bool userLoggin = this.userService.TryLogInUser(username, password);
            //if (!userLoggin)
            //{
            //    throw new ArgumentException("Invalid credentials");
            //}            
            //return this.menuFactory.CreateMenu("MainMenu");

            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length-"Command".Length);

            IMenu menu = this.menuFactory.CreateMenu(menuName);

            return menu;
        }
    }
}

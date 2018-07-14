using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    class SignUpCommand : ICommand
    {
        private IMenuFactory menuFactory;
        private IUserService userService;

        public SignUpCommand(IMenuFactory menuFactory, IUserService userService)
        {
            this.menuFactory = menuFactory;
            this.userService = userService;
        }

        public IMenu Execute(params string[] args)
        {
            var username = args[0];
            var password = args[1];

            bool success = this.userService.TrySignUpUser(username, password);

            if (!success)
            {
                throw new InvalidOperationException("Invalid login!");
            }

            return this.menuFactory.CreateMenu("MainMenu");
        }
    }
}

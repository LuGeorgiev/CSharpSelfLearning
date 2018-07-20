using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    public class ViewPostMenuCommand : ICommand
    {
        private ISession session;
        private IMenuFactory menuFactory;

        public ViewPostMenuCommand(ISession session, IMenuFactory menuFactory)
        {
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string commandName = this.GetType().Name;
            string menuName = commandName.Substring(0, commandName.Length - "Command".Length);
            IMenu menu = this.menuFactory.CreateMenu(menuName);

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                int postId = int.Parse(args[0]);
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}

using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    class PreviousPageCommand : ICommand
    {
        private ISession session;

        public PreviousPageCommand(ISession session)
        {
            this.session = session;
        }


        public IMenu Execute(params string[] args)
        {
            IMenu previousMenu = this.session.Back();
            if (previousMenu is IPaginatedMenu paginatedMenu)
            {
                paginatedMenu.ChangePage();
            }

            return previousMenu;
        }
    }
}

using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    class CategoriesMenuCommand : NavigationCommand
    { 
        public CategoriesMenuCommand(IMenuFactory menuFactory) 
            : base(menuFactory)
        {
        }
    }
}

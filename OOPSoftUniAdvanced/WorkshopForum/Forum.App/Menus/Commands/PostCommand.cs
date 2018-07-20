using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    public class PostCommand : ICommand
    {
        private IPostService postService;
        private ISession session;
        private IMenuFactory menuFactory;

        public PostCommand(IPostService postService, ISession session, IMenuFactory menuFactory)
        {
            this.postService = postService;
            this.session = session;
            this.menuFactory = menuFactory;
        }

        public IMenu Execute(params string[] args)
        {
            string title = args[0];
            string category = args[1];
            string content = args[2];
            int userId = this.session.UserId;

            bool validTitle = !string.IsNullOrWhiteSpace(title);
            bool validCategory = !string.IsNullOrWhiteSpace(category);
            bool validContent = !string.IsNullOrWhiteSpace(content);

            if (!validCategory||!validContent||!validTitle)
            {
                throw new ArgumentException("All must be filled in");
            }

            int postId = this.postService.AddPost(userId,title, category, content);

            IMenu menu = this.menuFactory.CreateMenu("ViewPostMenu");

            if (menu is IIdHoldingMenu idHoldingMenu)
            {
                idHoldingMenu.SetId(postId);
            }

            return menu;
        }
    }
}

using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Forum.App.Menus.Commands
{
    public class SubmitCommand : ICommand
    {
        private ISession session;
        private IPostService postService;

        public SubmitCommand(ISession session, IPostService postServic)
        {
            this.session = session;
            this.postService = postServic;
        }

        public IMenu Execute(params string[] args)
        {
            string replyText = args[0];
            if (string.IsNullOrWhiteSpace(replyText))
            {
                throw new ArgumentException("Cannot add empty reply");
            }
            int postId = int.Parse(args[1]);
            int authorId = this.session.UserId;

            this.postService.AddReplyToPost(postId, replyText, authorId);
            return this.session.Back();
        }
    }
}

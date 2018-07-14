using Forum.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Forum.App.ViewModels
{
    class PostViewModel :ContentViewModel, IPostViewModel
    {
        private string v1;
        private string content;
        private object v2;

        public PostViewModel(string title, string author, string conntent, IEnumerable<IReplyViewModel> replies) 
            : base(conntent)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray();
        }

        public PostViewModel(string conntent, string v1, string content, object v2) : base(conntent)
        {
            this.v1 = v1;
            this.content = content;
            this.v2 = v2;
        }

        public string Title { get; }

        public string Author { get; }

        //public string[] Content => throw new NotImplementedException();

        public IReplyViewModel[] Replies { get; }
    }
}

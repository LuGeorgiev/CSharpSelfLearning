using Forum.App.Contracts;
using System.Collections.Generic;
using System.Linq;


namespace Forum.App.ViewModels
{
    class PostViewModel :ContentViewModel, IPostViewModel
    {       

        public PostViewModel(string title, string author, string conntent, IEnumerable<IReplyViewModel> replies) 
            : base(conntent)
        {
            this.Title = title;
            this.Author = author;
            this.Replies = replies.ToArray();
        }

        public string Title { get; }

        public string Author { get; }

        //public string[] Content => throw new NotImplementedException();

        public IReplyViewModel[] Replies { get; }
    }
}

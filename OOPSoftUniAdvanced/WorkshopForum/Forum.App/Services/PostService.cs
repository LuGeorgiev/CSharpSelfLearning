using Forum.App.Contracts;
using Forum.App.ViewModels;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Forum.App.Services
{
    class PostService : IPostService
    {
        private ForumData forumData;
        private ISession session;
        private IUserService userService;

        public PostService(ForumData forumData, ISession session, IUserService userService)
        {
            this.forumData = forumData;
            this.session = session; // Not according to manual
            this.userService = userService;
        }


        public int AddPost(int userId, string postTitle, string postCategory, string postContent)
        {
            bool emptyCategory = string.IsNullOrEmpty(postCategory);
            bool emptyTitle = string.IsNullOrEmpty(postTitle);
            bool emptyContent = string.IsNullOrEmpty(postContent);

            if (emptyCategory||emptyContent||emptyTitle)
            {
                throw new ArgumentException("All fields must be filled!"); 
            }

            Category category = this.EnnsureCategory(postCategory);

            int postId = forumData.Posts.Any() ? forumData.Posts.Last().Id + 1 : 1;

            User author = this.userService.GetUserById(userId);

            Post post = new Post(postId, postTitle, postContent, category.Id, userId, new List<int>());

            forumData.Posts.Add(post);
            author.Posts.Add(post.Id);
            category.Posts.Add(post.Id);
            forumData.SaveChanges();

            return post.Id;
        }

        private Category EnnsureCategory(string postCategory)
        {
            var category = this.forumData.Categories
                .FirstOrDefault(c => c.Name == postCategory);
            if (category==null)
            {
                int categoryId = forumData.Categories.Any() ? forumData.Categories.Last().Id + 1 : 1;
                this.forumData.Categories.Add(new Category(categoryId, postCategory, new List<int>()));
                this.forumData.SaveChanges();

                return this.forumData.Categories
                .FirstOrDefault(c => c.Name == postCategory);
            }

            return category;
        }

        public void AddReplyToPost(int postId, string replyContents, int userId)
        {
            Post post = this.forumData
                .Posts
                .Find(p => p.Id == postId);
            User author = this.userService
                .GetUserById(userId);
            int replyId = this.forumData.Replies.LastOrDefault()?.Id + 1 ?? 1;
            Reply reply = new Reply(replyId,replyContents,userId,postId);

            this.forumData.Replies.Add(reply);
            post.Replies.Add(replyId);
            this.forumData.SaveChanges();
        }

        public IEnumerable<ICategoryInfoViewModel> GetAllCategories()
        {
            IEnumerable<ICategoryInfoViewModel> categories = this.forumData
                .Categories
                .Select(c=>new CategoryInfoViewModel(c.Id,c.Name,c.Posts.Count));

            return categories;
        }

        public string GetCategoryName(int categoryId)
        {
            string categoryName = this.forumData
                .Categories
                .First(c => c.Id == categoryId)?.Name;

            if (categoryName==null)
            {
                throw new ArgumentException($"Category with id {categoryId} not found!");
            }
            return categoryName;
        }

        public IEnumerable<IPostInfoViewModel> GetCategoryPostsInfo(int categoryId)
        {
            var posts = this.forumData.Posts
                .Where(p => p.CategoryId == categoryId)
                .Select(x => new PostInfoViewModel(x.Id, x.Title, x.Replies.Count));

            return posts;
        }

        public IPostViewModel GetPostViewModel(int postId)
        {
            var post = this.forumData.Posts
                .FirstOrDefault(p => p.Id == postId);

            IPostViewModel postView = new PostViewModel(post.Title, this.userService.GetUserName(post.AuthorId), post.Content, this.GetPostReplies(postId));

            return postView;
        }

        private IEnumerable<IReplyViewModel> GetPostReplies(int postId)
        {
            IEnumerable<IReplyViewModel> replies = this.forumData
                .Replies
                .Where(r => r.PostId == postId)
                .Select(r => new ReplyViewModel(this.userService.GetUserName(r.AuthorId), r.Content));

            return replies;
        }
    }
}

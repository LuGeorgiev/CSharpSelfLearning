using Forum.App.Contracts;
using Forum.Data;
using Forum.DataModels;
using System;
using System.Linq;

namespace Forum.App.Services
{
    public class UseService : IUserService
    {
        private ForumData forumData;
        private ISession session;

        public UseService(ForumData forumData, ISession session)
        {
            this.forumData = forumData;
            this.session = session;
        }

        public User GetUserById(int userId)
        {
            User user = this.forumData.Users
                .FirstOrDefault(x => x.Id == userId);
            if (user == null)
            {
                throw new ArgumentNullException($"User with id {userId} do not exist");
            }

            return user;
        }

        public string GetUserName(int userId)
        {
            User user = this.GetUserById(userId);

            return user.Username;
        }

        public bool TryLogInUser(string username, string password)
        {
            if (string.IsNullOrEmpty(username)||string.IsNullOrEmpty(password))
            {
                return false;
            }

            User user = this.forumData
                .Users
                .FirstOrDefault(u => u.Username == username && u.Password == password);

            if (user==null)
            {
                return false;
            }

            session.Reset();
            session.LogIn(user);

            return true;
        }

        public bool TrySignUpUser(string username, string password)
        {
            bool validUsername = !string.IsNullOrEmpty(username) && username.Length > 3;
            bool validPassword = !string.IsNullOrEmpty(password) && password.Length > 3;

            if (!validPassword||!validUsername)
            {
                throw new ArgumentException("Username and Password must be longer than 3 symbols!");
            }

            bool userAlraedyExists = this.forumData.Users
                .Any(u => u.Username == username);
            if (userAlraedyExists)
            {

                throw new InvalidOperationException("Username taken!");
            }

            int userId = forumData.Users.LastOrDefault()?.Id + 1 ?? 1;
            User user = new User(userId, username, password);
            this.forumData.Users.Add(user);
            this.forumData.SaveChanges();

            this.TryLogInUser(username, password);

            return true;
        }
    }
}

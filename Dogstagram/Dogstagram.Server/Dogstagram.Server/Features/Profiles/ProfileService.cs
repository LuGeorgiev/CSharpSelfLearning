using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Features.Profiles.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Profiles
{
    public class ProfileService : IProfileService
    {
        private readonly DogstagramDbContext db;

        public ProfileService(DogstagramDbContext db)
        {
            this.db = db;
        }

        public async Task<ProfileServiceModel> ByUser(string id)
            => await this.db.Users
            .Where(u => u.Id == id)
            .Select(u => new ProfileServiceModel
            {
                Name = u.Profile.Name,
                Biography = u.Profile.Biography,
                Gender = u.Profile.Gender.ToString(),
                ProfilePhotoUrl = u.Profile.ManinPhotoUrl,
                WebSite = u.Profile.WebSite,
                IsPrivate = u.Profile.IsPrivate
            })
            .FirstOrDefaultAsync();

        public async Task<Result> Update(
            string userId,
            string email,
            string userName,
            string name,
            string mainPhotoUrl,
            string webSite,
            string biography,
            Gender gender,
            bool isPrivate)
        {
            var user = await this.db
                .Users
                .Include(u => u.Profile)
                .FirstOrDefaultAsync(x => x.Id == userId);

            if (user == null)
            {
                return "Not existing user";
            }

            if (user.Profile == null)
            {
                user.Profile = new Profile();
            }

            var result = await this.ChanegProfileEmail(user, userId, email);
            if (result.Failure)
            {
                return result;
            }

            result = await this.ChanegProfileUserNAme(user, userId, userName);
            if (result.Failure)
            {
                return result;
            }

            this.ChangeOfProfile(user, name, mainPhotoUrl, webSite, biography, gender, isPrivate);

            await this.db.SaveChangesAsync();

            return true;
        }

        private async Task<Result> ChanegProfileEmail(User user, string userId, string email)
        {
            if (!string.IsNullOrWhiteSpace(email) && user.Email != email)
            {
                var emailExists = await this.db
                    .Users
                    .AnyAsync(x => x.Id != userId && x.Email == email);
                if (emailExists)
                {
                    //return false;
                    return "The provided email is already taken.";
                }

                user.Email = email;
            }

            return true;
        }

        private async Task<Result> ChanegProfileUserNAme(User user, string userId, string userName)
        {
            if (!string.IsNullOrWhiteSpace(userName) && user.UserName != userName)
            {
                var userNameExists = await this.db
                    .Users
                    .AnyAsync(u => u.Id != userId && u.UserName == userName);
                if (userNameExists)
                {
                    return "This userName is already taken.";
                }
                user.UserName = userName;
            }

            return true;
        }

        private void ChangeOfProfile(User user, string name, string mainPhotoUrl, string webSite, string biography, Gender gender, bool isPrivate)
        {
            if (user.Profile.Name != name)
            {
                user.Profile.Name = name;
            }

            if (user.Profile.ManinPhotoUrl != mainPhotoUrl)
            {
                user.Profile.ManinPhotoUrl = mainPhotoUrl;
            }

            if (user.Profile.WebSite != webSite)
            {
                user.Profile.WebSite = webSite;
            }

            if (user.Profile.Biography != biography)
            {
                user.Profile.Biography = biography;
            }

            if (user.Profile.Gender != gender)
            {
                user.Profile.Gender = gender;
            }

            if (user.Profile.IsPrivate != isPrivate)
            {
                user.Profile.IsPrivate = isPrivate;
            }
        }
    }
}

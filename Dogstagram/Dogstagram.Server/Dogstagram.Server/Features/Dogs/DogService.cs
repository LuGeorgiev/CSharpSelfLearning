using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Features.Dogs.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Dogs
{
    public class DogService : IDogService
    {
        private readonly DogstagramDbContext db;

        public DogService(DogstagramDbContext db)
        {
            this.db = db;
        }


        public async Task<string> CreateDog(string userId, string url, string description)
        {
            var dog = new Dog
            {
                Description = description,
                ImageUrl = url,
                UserId = userId
            };

            db.Dogs.Add(dog);
            await db.SaveChangesAsync();

            return dog.Id;
        }

        public async Task<IEnumerable<DogListingServiceModel>> ByUser(string userId)
            => await this.db.Dogs
                        .Where(x => x.UserId == userId)
                        .Select(x => new DogListingServiceModel
                        {
                            Id = x.Id,
                            ImageUrl = x.ImageUrl
                        })
                        .ToListAsync();

        public async Task<DogDetailsServiceModel> DetailsByDogId(string dogId)
            => await this.db.Dogs
                         .Where(x => x.Id == dogId)
                         .Select(x => new DogDetailsServiceModel
                         {
                             Id = x.Id,
                             Description = x.Description,
                             ImageUrl = x.ImageUrl,
                             UserId = x.UserId,
                             UserName = x.User.UserName
                         })
                        .FirstOrDefaultAsync();

        public async Task<bool> Update(string dogId, string description, string userId)
        {
            var dog = await GetDogByIdAndUser(dogId, userId);

            if (dog == null)
            {
                return false;
            }
            dog.Description = description;
            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> Delete(string id, string userId)
        {
            var dog = await GetDogByIdAndUser(id, userId);

            if (dog == null)
            {
                return false;
            }

            this.db.Dogs.Remove(dog);
            await this.db.SaveChangesAsync();
            return true;
        }

        private async Task<Dog> GetDogByIdAndUser(string id, string userId)
        => await this.db
                .Dogs
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == userId);
        
    }
}

using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using System;
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
    }
}

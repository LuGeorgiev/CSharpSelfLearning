using Dogstagram.Server.Data;
using Dogstagram.Server.Features.Profiles.Models;
using Dogstagram.Server.Features.Search.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Search
{
    public class SearchService : ISearchService
    {
        private readonly DogstagramDbContext db;

        public SearchService(DogstagramDbContext db)
        {
            this.db = db;
        }

        public async Task<IEnumerable<SearchServiceModel>> Profile(string query)
         => await this.db
            .Users
            .Where(u => u.UserName.ToLower().Contains(query.ToLower()) ||
                    u.Profile.Name.ToLower().Contains(query.ToLower()))
            .Select(u => new SearchServiceModel
            {
                ProfilePhotoUrl = u.Profile.ManinPhotoUrl,
                UserId = u.Id,
                UserName = u.UserName
            })
            .ToListAsync();
    }
}

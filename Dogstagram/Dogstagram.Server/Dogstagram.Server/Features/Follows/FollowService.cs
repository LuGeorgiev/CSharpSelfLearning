using Dogstagram.Server.Data;
using Dogstagram.Server.Data.Models;
using Dogstagram.Server.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Dogstagram.Server.Features.Follows
{
    public class FollowService : IFollowService
    {
        private readonly DogstagramDbContext db;

        public FollowService(DogstagramDbContext db) => this.db = db;

        public async Task<Result> Follow(string userId, string followerId)
        {
            var userAlreadyFollowed = await this.db
                .Follows
                .AnyAsync(f => f.UserId == userId && f.FollowerId == followerId);
            if (userAlreadyFollowed)
            {
                return "Already followed user!";
            }

            var publicProfile = await this.db
                .Profiles
                .Where(p => p.UserId == userId)
                .Select(x => x.IsPrivate)
                .FirstOrDefaultAsync();

            this.db.Follows.Add(new Follow()
            {
                UserId = userId,
                FollowerId = followerId,
                IsApprove = publicProfile
            });

            await this.db.SaveChangesAsync();

            return true;
        }

        public async Task<bool> IsFollower(string userId, string followerId)
            => await this.db
                .Follows
                .AnyAsync(f => f.UserId == userId &&
                    f.FollowerId == followerId &&
                    f.IsApprove);
    }
}

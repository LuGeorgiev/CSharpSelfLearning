
using System.ComponentModel.DataAnnotations;

namespace Dogstagram.Server.Data.Models
{
    public class Follow
    {
        public int Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

        [Required]
        public string FollowerId { get; set; }

        public User Follower { get; set; }

        public bool IsApprove { get; set; }
    }
}

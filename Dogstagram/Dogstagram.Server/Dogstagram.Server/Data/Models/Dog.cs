using Dogstagram.Server.Data.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;

using static Dogstagram.Server.Data.Validation.Dog;

namespace Dogstagram.Server.Data.Models
{
    public class Dog : DeletableEntity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }


        [Required]
        public string UserId { get; set; }

        public User User { get; set; }

    }
}

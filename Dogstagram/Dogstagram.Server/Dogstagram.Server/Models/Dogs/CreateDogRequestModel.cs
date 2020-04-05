using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

using static Dogstagram.Server.Data.Validation.Dog;


namespace Dogstagram.Server.Models.Dogs
{
    public class CreateDogRequestModel
    {
        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}

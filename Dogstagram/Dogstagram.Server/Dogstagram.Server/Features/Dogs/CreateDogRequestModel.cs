using System.ComponentModel.DataAnnotations;

using static Dogstagram.Server.Data.Validation.Dog;


namespace Dogstagram.Server.Features.Dogs
{
    public class CreateDogRequestModel
    {
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        [Required]
        public string ImageUrl { get; set; }
    }
}

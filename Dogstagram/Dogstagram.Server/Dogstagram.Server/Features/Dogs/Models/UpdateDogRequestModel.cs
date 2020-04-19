using System.ComponentModel.DataAnnotations;

using static Dogstagram.Server.Data.Validation.Dog;

namespace Dogstagram.Server.Features.Dogs.Models
{
    public class UpdateDogRequestModel
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }
    }
}

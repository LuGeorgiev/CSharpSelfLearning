using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertyViewModel
    {
        public int Id { get; set; }


        [Display(Name = DisplayPropertyName)]
        public string Name { get; set; }


        [Display(Name = DisplayAddress)]
        public string Address { get; set; }


        [Display(Name = DisplayArea)]
        public int Area { get; set; }


        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }
    }
}

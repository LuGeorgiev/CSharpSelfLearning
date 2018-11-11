﻿using EstateManagment.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;
using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertyDetailsModel
    {
        public int Id { get; set; }

        [Required]
        [MinLength(PropertyNameMinLength)]
        [MaxLength(PropertyNameMaxLength)]
        public string Name { get; set; }

        [Required]
        [MinLength(PropertyAddressMinLength)]
        [MaxLength(PropertyAddressMaxLength)]
        public string Address { get; set; }

        [Required]
        [Range(PropertyMinArea, PropertyMaxArea)]
        public int Area { get; set; }

        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        public PropertyType Type { get; set; }

        public bool IsActual { get; set; } 
    }
}

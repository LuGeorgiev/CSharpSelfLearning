
namespace CarDealer.Web.Models.Parts
{
    using System.ComponentModel.DataAnnotations;
    using System.Collections.Generic;
    using Services.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PartFormModel
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public decimal Price { get; set; }

        [Range(1, int.MaxValue,ErrorMessage ="Price must be positive number.")]
        public int Quantity { get; set; }

        [Display(Name="Supplier")]
        public int SupplierId { get; set; }

        public IEnumerable<SelectListItem> Suppliers { get; set; }

        public bool IsEdit { get; set; }
    }
}

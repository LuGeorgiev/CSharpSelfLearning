
namespace CarDealer.Web.Models.Customers
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CustomerFormModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Display(Name="Young Driver")]
        public bool IsYoungDriver { get; set; }
    }
}

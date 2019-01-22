using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyRents
{
    public class InvoiceBindingModel
    {
        [Range(InvoiceMinNumber, InvoiceMaxNumber)]
        [Display(Name = DisplayInvoiceNumber)]
        [Required]
        public int InvoiceNumber { get; set; }

        public int Id { get; set; }
    }
}

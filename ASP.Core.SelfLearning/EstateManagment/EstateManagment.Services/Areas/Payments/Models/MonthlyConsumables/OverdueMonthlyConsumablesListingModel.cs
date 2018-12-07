using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyConsumables
{
    public class OverdueMonthlyConsumablesListingModel
    {
        public decimal PaymentForWater { get; set; }
        
        public decimal PaymentForElectricity { get; set; }     

        [DataType(DataType.Date)]
        public DateTime DeadLine { get; set; }

        public IEnumerable<string> PropertyRentsNames { get; set; }
       
        public string ClientName { get; set; }
    }
}

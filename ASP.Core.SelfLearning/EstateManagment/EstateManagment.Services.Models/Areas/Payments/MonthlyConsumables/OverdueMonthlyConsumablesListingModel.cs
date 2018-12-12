using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Services.Models.Areas.Payments.MonthlyConsumables
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

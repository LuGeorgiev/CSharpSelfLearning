using System;
using System.Collections.Generic;

namespace EstateManagment.Services.Areas.Payments.Models.MonthlyRents
{
    public class OverdueMontlyRentsListingModel
    {      
        public DateTime DeadLine { get; set; }
      
        public decimal TotalPayment { get; set; }

        public bool ApplyVAT { get; set; }
                
        public IEnumerable<string> PropertyRentsNames { get; set; }

        public int ParkingSlotsQty { get; set; }

        public int MonthsOverdue { get; set; }

        public string ClientName { get; set; }
    }
}

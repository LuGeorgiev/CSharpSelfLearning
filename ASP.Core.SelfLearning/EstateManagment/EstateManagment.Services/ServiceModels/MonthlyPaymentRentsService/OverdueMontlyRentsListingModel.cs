using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.MonthlyPaymentRentsService
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

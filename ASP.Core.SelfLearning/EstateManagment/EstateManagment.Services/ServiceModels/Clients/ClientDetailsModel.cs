using EstateManagment.Services.ServiceModels.Rents;
using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Clients
{
    public class ClientDetailsModel
    {
        public string Name { get; set; }
        
        public string Address { get; set; }

        public string Bulstat { get; set; }
                
        public string EGN { get; set; }
                
        public string AccountableName { get; set; }

        public string ContactName { get; set; }

        public string Telephone { get; set; }
                
        public string Notes { get; set; }

        public IEnumerable<RentAgreementShortModel> RentAgreements { get; set; }
    }
}

using EstateManagment.Services.Models.Rents;
using System.Collections.Generic;

namespace EstateManagment.Services.Models.Clients
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

        public string Email { get; set; }

        public IEnumerable<RentAgreementShortModel> RentAgreements { get; set; }
    }
}

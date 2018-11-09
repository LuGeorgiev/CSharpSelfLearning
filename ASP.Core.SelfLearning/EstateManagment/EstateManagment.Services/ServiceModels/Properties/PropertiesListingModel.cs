using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertiesListingModel
    {
        public int CompanyId { get; set; }

        public string CompanyName { get; set; }

        public IEnumerable<PropertyViewModel> Properties {get; set;}
    }
}

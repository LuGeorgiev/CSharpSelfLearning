using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertyViewModel
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
       
        public string Address { get; set; }
        
        public int Area { get; set; }

        public string Description { get; set; }
    }
}

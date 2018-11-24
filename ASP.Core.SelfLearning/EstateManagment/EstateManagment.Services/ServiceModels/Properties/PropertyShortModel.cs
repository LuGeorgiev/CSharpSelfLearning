using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.DataConstants;

namespace EstateManagment.Services.ServiceModels.Properties
{
    public class PropertyShortModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Area { get; set; }
    }
}

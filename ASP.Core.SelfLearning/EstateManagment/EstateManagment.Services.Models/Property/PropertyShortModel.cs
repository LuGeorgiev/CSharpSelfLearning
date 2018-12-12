using System.ComponentModel.DataAnnotations;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.Models.Property
{
    public class PropertyShortModel
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int Area { get; set; }
    }
}

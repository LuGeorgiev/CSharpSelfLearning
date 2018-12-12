using EstateManagment.Services.ServiceModels.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using static EstateManagment.Data.Models.DataConstants;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class RentDetailsModel
    {
        public int Id { get; set; }

        [Display(Name = DisplayPrice)]
        public decimal MonthlyPrice { get; set; }
                
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime? EndDate { get; set; }

        [Display(Name = DisplayDescription)]
        public string Description { get; set; }

        [MaxLength(DescriptionMaxLength)]
        [Display(Name = DisplayParkingDecription)]
        public string ParkingSlotDescription { get; set; }
        
        public string Client { get; set; }

        public IEnumerable<PropertyShortModel> Properties { get; set; }

        public IEnumerable<ParkingSlotShortModel> ParkingSlots { get; set; }

        public decimal TotalMonthlyPrice
        {
            get
            {
                return this.MonthlyPrice + this.ParkingSlots.Sum(x => int.Parse(x.Quantity) * x.Price);
            }
        }
    }
}

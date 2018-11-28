using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Services.ServiceModels.Rents
{
    public class RentAgreementShortModel
    {
        public int Id { get; set; }

        public IEnumerable<string> PropertyName { get; set; }

        public int ParkingPlacesQuantity { get; set; }

        public decimal TotalPrice { get; set; }

        public DateTime StartDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? EndDate { get; set; }
    }
}

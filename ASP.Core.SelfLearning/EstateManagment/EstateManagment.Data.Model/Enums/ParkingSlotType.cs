using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Data.Models.Enums
{
    public enum ParkingSlotType
    {
        [Description("Кола")]
        Car = 1,
        [Description("Рейс")]
        Bus = 2,
        [Description("Камион")]
        Truck = 3,
        [Description("Голям Камион")]
        BigTruck = 4,
        [Description("Автомобилна Клетка")]
        CarCage = 5,
        [Description("Друго")]
        Other = 6
    }
}

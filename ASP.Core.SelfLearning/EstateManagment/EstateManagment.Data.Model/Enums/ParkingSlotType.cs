using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Data.Models.Enums
{
    public enum ParkingSlotType
    {
        [Display(Name ="Кола")]
        Car = 1,
        [Display(Name ="Рейс")]
        Bus = 2,
        [Display(Name ="Камион")]
        Truck = 3,
        [Display(Name ="Голям Камион")]
        BigTruck = 4,
        [Display(Name ="Автомобилна Клетка")]
        CarCage = 5,
        [Display(Name ="Друго")]
        Other = 6
    }
}

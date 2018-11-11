using System.ComponentModel.DataAnnotations;

namespace EstateManagment.Data.Models.Enums
{
    public enum PropertyType
    {
        [Display(Name ="Стая")]
        Room = 1,
        [Display(Name = "Склад")]
        Warehouse = 2,
        [Display(Name = "Офис")]
        Office = 3,
        [Display(Name = "Друго")]
        Other = 4
    }
}

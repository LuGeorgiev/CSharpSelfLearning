
namespace CarDealer.Services.Models.Sales
{
    using Cars;

    public class SaleDetailsModel:SaleListModel
    {
        public CarModel Car { get; set; }
    }
}

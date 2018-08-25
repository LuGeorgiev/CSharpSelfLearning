namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models.Sales;

    public interface ISaleService
    {
        IEnumerable<SaleListModel> All();

        SaleDetailsModel ById(int id);

        IEnumerable<SaleListModel> Discounted();

        IEnumerable<SaleListModel> DiscountedByPercent(double percent);
    }
}

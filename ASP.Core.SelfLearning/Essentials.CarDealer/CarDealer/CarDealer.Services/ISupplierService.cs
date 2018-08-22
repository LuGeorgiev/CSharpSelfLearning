namespace CarDealer.Services
{
    using System.Collections.Generic;
    using Models;

    public interface ISupplierService
    {
        IEnumerable<SupplierModel> All(bool isImporter);
    }
}

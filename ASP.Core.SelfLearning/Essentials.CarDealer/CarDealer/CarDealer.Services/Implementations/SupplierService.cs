
namespace CarDealer.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CarDealer.Data;
    using Models.Suppliers;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All()
            => this.db.Suppliers
            .OrderBy(s => s.Name)
            .Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name
            })
            .ToList();

        public IEnumerable<SupplierListingModel> AllListings(bool isImporter)
        => this.db.Suppliers
            .Where(s => s.IsImporter == isImporter)
            .OrderByDescending(s=>s.Id)
            .Select(s=> new SupplierListingModel
            {
                Id=s.Id,
                Name=s.Name,
                TotalParts = s.Parts.Count
            })
            .ToList();
    }
}

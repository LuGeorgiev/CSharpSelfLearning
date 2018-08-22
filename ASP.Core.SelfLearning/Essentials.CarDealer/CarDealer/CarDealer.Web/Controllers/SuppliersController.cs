namespace CarDealer.Web.Controllers
{
    using CarDealer.Web.Models.Suppliers;
    using Microsoft.AspNetCore.Mvc;
    using Services;

    public class SuppliersController:Controller
    {
        private const string SuppliersView = "Suppliers";
        private readonly ISupplierService suppliers;

        public SuppliersController(ISupplierService suppliers)
        {
            this.suppliers = suppliers;
        }

        public IActionResult Local()
        {
            return View(SuppliersView, this.GetSupplierModel(false));
        }

        public IActionResult Importers()
        {
            return View(SuppliersView, this.GetSupplierModel(true));

        }

        private SuppliersModel GetSupplierModel(bool importer)
        {
            var type = importer ? "Importer" : "Local";

            var suppliers = this.suppliers.All(importer);

            return new SuppliersModel
            {
                Type = type,
                Suppliers = suppliers
            };
        }
    }
}

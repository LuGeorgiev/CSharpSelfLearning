namespace CarDealer.Web.Models.Suppliers
{
    using Services.Models;
    using System.Collections.Generic;

    public class SuppliersModel
    {
        public string Type { get; set; }

        public IEnumerable<SupplierModel> Suppliers {get; set; }
    }
    
}

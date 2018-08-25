using CarDealer.Services.Models.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealer.Web.Models.Sales
{
    public class SalesModel
    {
        public IEnumerable<SaleListModel> AllSales { get; set; }
    }
}

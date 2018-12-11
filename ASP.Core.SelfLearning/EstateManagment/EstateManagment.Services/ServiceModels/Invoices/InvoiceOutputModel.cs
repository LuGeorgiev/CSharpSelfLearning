using System;
using System.Collections.Generic;
using System.Text;

namespace EstateManagment.Services.ServiceModels.Invoices
{
    public class InvoiceOutputModel
    {
        public decimal VAT { get; set; } = 200;

        public string Name { get; set; } = "FirmaFirma";

        public string Bulstat { get; set; } = "BG070845986";
    }
}

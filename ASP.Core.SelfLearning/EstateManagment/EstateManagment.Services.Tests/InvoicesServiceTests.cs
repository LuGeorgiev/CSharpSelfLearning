using EstateManagment.Services.Implementation;
using EstateManagment.Services.Models.Invoices;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace EstateManagment.Services.Tests
{
    public class InvoicesServiceTests
    {
        [Fact]
        public async Task GetViewModelAsync_ShouldThrow_NotImplemetedException()
        {
            var invoiceService = new InvoicesService();
            var inputModel = new InvoiceInputModel() {Name="Firma Frma", Price=800 };

            Action act = ()=>  invoiceService.GetViewModelAsync(inputModel);

                act
                .Should()
                .ThrowExactly<InvalidOperationException>()
                .WithMessage("Not impelmented");            
        }
    }
}

using EstateManagment.Services.Areas.Payments.Models.MonthlyRents;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EstateManagment.Services.Areas.Payments
{
    public interface IMonthlyRentsService
    {
        Task<CreateMonthlyRentFormViewModel> GetDetailsAsync(int rentAgreementId);

        Task<IEnumerable<MonthlyRentListingModel>> AllNotPaidAsync(bool isPaid = false);

        Task<bool> CreateAsync(int idRentAgreement, decimal totalPayment, DateTime deadLine, bool applyVat);
    }
}

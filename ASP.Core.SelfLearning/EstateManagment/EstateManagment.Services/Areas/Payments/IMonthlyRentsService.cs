using EstateManagment.Services.Areas.Payments.Models;
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

        Task<MonthlyRentViewModel> GetByIdAsync(int id);

        Task<bool> CreateNextMonthPayment(int monthlyRentId);

        Task<bool> EditAsync(MonthlyRentViewModel model);

        Task<bool> Terminate(int id);

        Task<IEnumerable<OverdueMontlyRentsListingModel>> AllOverdueRentsAsync();
    }
}

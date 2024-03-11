using HauseCalcApi.Models;

namespace HauseCalcApi.Core
{
    public interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
        Task FillDatabaseCalculationCustomerAsync(UserCalculationRequest setServiceClient);
        Task<UserCalculationRequest> GetCalculationCost(Guid guid);
        Task FillDatabaseContactsAsync(UserContacts userContacts);
        Task<List<UserContacts>> GetAllUserContacts();
    }
}



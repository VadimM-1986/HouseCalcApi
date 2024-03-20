using HauseCalcApi.Models;

namespace HauseCalcApi.Core
{
    public interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
        Task FillDatabaseCalculationCustomerAsync(UserCalculationRequest setServiceClient);
        Task<UserCalculationRequest> GetCalculationCost(Guid guid);
        Task<int?> FillDatabaseContactsAsync(UserContacts userContacts);
        Task<List<UserContacts>> GetAllUserContacts();
        Task<UserContacts> GetUser(int userId);
    }
}



using HauseCalcApi.Models;

namespace HauseCalcApi.Core
{
    public interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
        Task FillDatabaseCalculationCustomerAsync(UserCalculationRequest setServiceClient);
        Task<UserCalculationRequest> GetCalculationCost(Guid guid);
        Task<int?> FillDatabaseContactsAsync(UserContactDTO userContactDTO);
        Task AddUserRequestIds(int userContactId, List<Guid> UserRequestLists);
        Task<List<UserContact>> GetAllUserContacts();
        Task<UserContact> GetUser(int userId);
        Task<List<UserCalculationRequest>> GetCalculationRequestUser(int userContactId);
    }
}



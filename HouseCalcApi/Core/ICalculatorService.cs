using HouseCalcApi.Models;

namespace HouseCalcApi.Core
{
    public interface ICalculatorService
    {
        Task<Guid> UserCalculationRequest(UserCalculationRequestDTO costService);
        Task<UserCalculationRequest> GetCalculationCost(Guid externalId);
        Task<int?> UserContactsAdd(UserContactDTO userContactDTO);
        Task<List<UserContact>> GetAllOrders();
        Task<UserOrder> GetOrder(int userId);
    }
}


using HauseCalcApi.Data;
using HauseCalcApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;

namespace HauseCalcApi.Core
{
    public interface ICalculatorService
    {
        Task<Guid> UserCalculationRequest(UserCalculationRequestDTO costService);
        Task<UserCalculationRequest> GetCalculationCost(Guid externalId);
        Task<int?> UserContactsAdd(UserContact userContacts);
        Task<List<UserContact>> GetAllOrders();
        Task<UserOrder> GetOrder(int userId);
    }
}


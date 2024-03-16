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
        Task UserContactsAdd(UserContacts userContacts);
        Task<List<UserContacts>> GetAllOrders();
        Task<UserOrder> GetOrder(int userId);
    }
}


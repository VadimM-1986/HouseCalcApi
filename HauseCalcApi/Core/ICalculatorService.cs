using HauseCalcApi.Data;
using HauseCalcApi.Models;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;

namespace HauseCalcApi.Core
{
    public interface ICalculatorService
    {
        Task<Guid> UserCalculationRequest(UserCalculationRequestDTO costService);
        Task<UserCalculationRequest> GetCalculationCost(Guid guid);
    }
}


using HauseCalcApi.Data;
using HauseCalcApi.Models;
using Microsoft.CodeAnalysis;
using System.Threading.Tasks;

namespace HauseCalcApi.Core
{
    public interface ICalculatorService
    {
        Task<Guid> SetCalculationClient(SetServiceClientDTO costService);
        Task<SetServiceClient> GetCalculationCost(Guid guid);
    }
}


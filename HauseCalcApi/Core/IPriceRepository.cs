using HauseCalcApi.Models;

namespace HauseCalcApi.Core
{
    public interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
        Task FillDatabaseCalculationCustomerAsync(SetServiceClient setServiceClient);
        Task<SetServiceClient> GetCalculationCost(Guid guid);
    }
}



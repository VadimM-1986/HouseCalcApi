namespace HauseCalcApi.Core
{
    public interface IPriceRepository
    {
        Task<int> GetPriceByIdAsync(int id);
    }
}



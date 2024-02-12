using HauseCalcApi.Core;
using Microsoft.EntityFrameworkCore;
namespace HauseCalcApi.Data
{
    public class PriceRepository : IPriceRepository
    {

        private readonly Models.AppContext _context;
        
        public PriceRepository(Models.AppContext context)
        {
            _context = context;
        }

        // Соединение с БД
        public async Task<int> GetPriceByIdAsync(int id)
        {
            int resault = 0;

            var komplektObject = await _context.Prices.SingleOrDefaultAsync(el => el.Id == id);

            if (komplektObject == null)
            {
                throw new InvalidOperationException($"Price is not found ID: {id}");
            }
            else
            {
                resault = komplektObject.Value;
            }

            return resault;
        }
    }
}

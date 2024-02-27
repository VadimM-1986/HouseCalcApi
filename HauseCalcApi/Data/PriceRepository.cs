using HauseCalcApi.Core;
using HauseCalcApi.Models;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace HauseCalcApi.Data
{
    public class PriceRepository : IPriceRepository
    {

        private readonly Models.AppContext _context;
        
        public PriceRepository(Models.AppContext context)
        {
            _context = context;
        }

        // Price receipt
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


        // Customer Billing Fill Database
        public async Task FillDatabaseCalculationCustomerAsync(SetServiceClient setServiceClient)
        {
            var setServiceClients = new List<SetServiceClient>
            {
                new SetServiceClient
                {
                    IdGuid = setServiceClient.IdGuid,
                    Id = setServiceClient.Id,
                    areaHouseSquarMeters = setServiceClient.areaHouseSquarMeters,
                    Walls = setServiceClient.Walls,
                    Projects = setServiceClient.Projects,
                    Geology = setServiceClient.Geology,
                    Geodesy = setServiceClient.Geodesy,
                    Construction = setServiceClient.Construction,
                    Armo = setServiceClient.Armo,
                    Seams = setServiceClient.Seams,
                    DeliveryDistanceKilometers = setServiceClient.DeliveryDistanceKilometers,
                    Fundation = setServiceClient.Fundation,
                    Roof = setServiceClient.Roof,
                    FiledWindowArea = setServiceClient.FiledWindowArea,
                    Door = setServiceClient.Door,
                    AllCost = setServiceClient.AllCost
                },
            };

            await _context.SetServiceClients.AddRangeAsync(setServiceClients);
            await _context.SaveChangesAsync();
        }


        // Get a calculation
        public async Task<SetServiceClient> GetCalculationCost(Guid guid)
        {
            SetServiceClient calculationCost = await _context.SetServiceClients.SingleOrDefaultAsync(el => el.IdGuid ==  guid);

            if (calculationCost == null)
            {
                throw new InvalidOperationException($"Is not found guid: {guid}");
            }
            return calculationCost;
        }
    }
}

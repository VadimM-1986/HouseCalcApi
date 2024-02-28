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
        public async Task FillDatabaseCalculationCustomerAsync(UserCalculationRequest setServiceClient)
        {
            var setServiceClients = new List<UserCalculationRequest>
            {
                new UserCalculationRequest
                {
                    ExternalId = setServiceClient.ExternalId,
                    Id = setServiceClient.Id,
                    AreaHouseSquarMeters = setServiceClient.AreaHouseSquarMeters,
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
                    AllCost = setServiceClient.AllCost,
                    DateTime = setServiceClient.DateTime
                },
            };

            await _context.SetServiceClients.AddRangeAsync(setServiceClients);
            await _context.SaveChangesAsync();
        }


        // Get a calculation
        public async Task<UserCalculationRequest> GetCalculationCost(Guid externalId)
        {
            UserCalculationRequest calculationCost = await _context.SetServiceClients.SingleOrDefaultAsync(el => el.ExternalId == externalId);

            if (calculationCost == null)
            {
                throw new InvalidOperationException($"Is not found guid: {externalId}");
            }
            return calculationCost;
        }
    }
}

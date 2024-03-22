using HauseCalcApi.Core;
using HauseCalcApi.Models;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
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
                    RequestId = setServiceClient.RequestId,
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
                }
        };

            await _context.SetServiceClients.AddRangeAsync(setServiceClients);
            await _context.SaveChangesAsync();
        }


        // Get a calculation
        public async Task<UserCalculationRequest> GetCalculationCost(Guid requestId)
        {
            UserCalculationRequest? calculationCost = await _context.SetServiceClients.SingleOrDefaultAsync(el => el.RequestId == requestId);
            return calculationCost;
        }


        // Get Guid User for Admin
        public async Task<List<UserCalculationRequest>> GetCalculationRequestUser(List<string> guids)
        {
            List<UserCalculationRequest> userCalculationRequestsOut = new List<UserCalculationRequest>();

            var query = from userCalculation in _context.SetServiceClients
                        join settlementId in _context.SetSettlementIDs
                        on userCalculation.RequestId equals settlementId.RequestID
                        select userCalculation;

            foreach (var guid in guids)
            {
                if (Guid.TryParse(guid, out Guid resultGuid))
                {
                    // Преобразование строки в GUID удалось, используем resultGuid
                    UserCalculationRequest? userCalculationRequest = await query.FirstOrDefaultAsync(x => x.RequestId == resultGuid);
                    if (userCalculationRequest != null)
                    {
                        userCalculationRequestsOut.Add(userCalculationRequest);
                    }
                }
            }

            return userCalculationRequestsOut;
        }


        // Add Database Contacts
        public async Task<int?> FillDatabaseContactsAsync(UserContact contact)
        {
            var userContacts = new List<UserContact>
            {
                new UserContact
                {
                    NameUser = contact.NameUser,
                    PhoneUser = contact.PhoneUser,
                    UserRequestLists = contact.UserRequestLists
                },
            };

            await _context.SetUserContacts.AddRangeAsync(userContacts);
            await _context.SaveChangesAsync();

            int? Id = userContacts.LastOrDefault()?.Id;


            // Add tsble SettlemmentIDs
            var settlementIDs = new List<SettlementID>();

            foreach (var requestID in contact.UserRequestLists)
            {
                var settlementID = new SettlementID()
                {
                    ContactID = (int)Id,
                    RequestID = Guid.Parse(requestID)
                };

                settlementIDs.Add(settlementID);
            }

            await _context.SetSettlementIDs.AddRangeAsync(settlementIDs);
            await _context.SaveChangesAsync();

            return Id;
        }


        // Get all orders
        public async Task<List<UserContact>> GetAllUserContacts()
        {
            List<UserContact> userContacts = await _context.SetUserContacts.ToListAsync();
            return userContacts;
        }


        // Get user
        public async Task<UserContact> GetUser(int userId)
        {
            UserContact? userContacts = await _context.SetUserContacts.SingleOrDefaultAsync(el => el.Id == userId);
            return userContacts;
        }
    }
}

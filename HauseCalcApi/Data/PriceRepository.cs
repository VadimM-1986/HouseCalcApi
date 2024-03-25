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

            await _context.UserCalculationRequests.AddRangeAsync(setServiceClients);
            await _context.SaveChangesAsync();
        }


        // Get a calculation
        public async Task<UserCalculationRequest> GetCalculationCost(Guid requestId)
        {
            UserCalculationRequest? calculationCost = await _context.UserCalculationRequests.SingleOrDefaultAsync(el => el.RequestId == requestId);
            return calculationCost;
        }


        // Get Guid User for Admin ---
        public async Task<List<UserCalculationRequest>> GetCalculationRequestUser(int userContactId)
        {
            var query = from userCalculationRequest in _context.UserCalculationRequests
                        join ClientRequestId in _context.ClientRequestIds
                        on userCalculationRequest.RequestId equals ClientRequestId.RequestID
                        where ClientRequestId.ContactID == userContactId
                        select userCalculationRequest;

            return await query.ToListAsync();
        }


        // Add Database Contacts
        public async Task<int?> FillDatabaseContactsAsync(UserContactDTO userContactDTO)
        {
            var userContacts = new List<UserContact>
            {
                new UserContact
                {
                    NameUser = userContactDTO.NameUser,
                    PhoneUser = userContactDTO.PhoneUser
                },
            };

            await _context.UserContacts.AddRangeAsync(userContacts);
            await _context.SaveChangesAsync();

            int userContactId = userContacts.LastOrDefault().Id;

            AddUserRequestIds(userContactId, userContactDTO.UserRequestLists);

            return userContactId;
        }


        public async Task AddUserRequestIds(int userContactId, List<Guid> userRequestLists)
        {
            var ClientRequestIds = new List<ClientRequestId>();

            foreach (var requestId in userRequestLists)
            {
                var ClientRequestId = new ClientRequestId()
                {
                    ContactID = userContactId,
                    RequestID = requestId
                };

                ClientRequestIds.Add(ClientRequestId);
            }

            await _context.ClientRequestIds.AddRangeAsync(ClientRequestIds);
            await _context.SaveChangesAsync();
        }


        // Get all orders
        public async Task<List<UserContact>> GetAllUserContacts()
        {
            List<UserContact> userContacts = await _context.UserContacts.ToListAsync();
            return userContacts;
        }


        // Get user
        public async Task<UserContact> GetUser(int userId)
        {
            UserContact? userContact = await _context.UserContacts.SingleOrDefaultAsync(el => el.Id == userId);
            return userContact;
        }
    }
}

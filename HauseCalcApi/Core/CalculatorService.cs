using HauseCalcApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace HauseCalcApi.Core
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly UserCalculationRequest _setService;
        private readonly UserContacts _userContacts;
        // Бизнес логика

        // Передаем Id услуги
        const int SETWALLS_ID = 1;
        const int PROJECT_ID = 2;
        const int GEOLOGI_ID = 3;
        const int GEODESY_ID = 4;
        const int CONSTRUCTION_ID = 5;
        const int ARMO_ID = 6;
        const int SEAMS_ID = 7;
        const int DELIVERY_ID = 8;
        const int FUNDATION_ID = 9;
        const int ROOF_ID = 10;
        const int WINDOWS_ID = 11;
        const int DOOR_ID = 12;

    public CalculatorService(IPriceRepository priceRepository)
    {
        _priceRepository = priceRepository;
        _setService = new UserCalculationRequest();
        _userContacts = new UserContacts();
        }

        public async Task<Guid> UserCalculationRequest(UserCalculationRequestDTO userCalculationRequest)
        {
            
            if (userCalculationRequest.AreaHouseSquarMeters <= 0)
            {
                throw new ArgumentException("The house area field is not filled in!");
            }
            else
            {
                _setService.RequestId = Guid.NewGuid();

                _setService.AreaHouseSquarMeters = userCalculationRequest.AreaHouseSquarMeters;

                if (userCalculationRequest.HasWalls)
                {
                    _setService.Walls = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(SETWALLS_ID);
                }

                if (userCalculationRequest.HasProjects)
                {
                    _setService.Projects = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(PROJECT_ID);
                }

                if (userCalculationRequest.HasGeology)
                {
                    _setService.Geology = await _priceRepository.GetPriceByIdAsync(GEOLOGI_ID);
                }

                if (userCalculationRequest.HasGeodesy)
                {
                    _setService.Geodesy = await _priceRepository.GetPriceByIdAsync(GEODESY_ID);
                }

                if (userCalculationRequest.HasConstruction)
                {
                    _setService.Construction = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(CONSTRUCTION_ID);
                }

                if (userCalculationRequest.HasArmo)
                {
                    _setService.Armo = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(ARMO_ID);
                }

                if (userCalculationRequest.HasSeams)
                {
                    _setService.Seams = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(SEAMS_ID);
                }

                if (userCalculationRequest.DeliveryDistanceKilometers >= 0)
                {
                    _setService.DeliveryDistanceKilometers = userCalculationRequest.DeliveryDistanceKilometers * await _priceRepository.GetPriceByIdAsync(DELIVERY_ID);
                }

                if (userCalculationRequest.HasFundation)
                {
                    _setService.Fundation = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(FUNDATION_ID);
                }

                if (userCalculationRequest.HasRoof)
                {
                    _setService.Roof = userCalculationRequest.AreaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(ROOF_ID);
                }

                if (userCalculationRequest.FiledWindowArea >= 0)
                {
                    _setService.FiledWindowArea = userCalculationRequest.FiledWindowArea * await _priceRepository.GetPriceByIdAsync(WINDOWS_ID);
                }

                if (userCalculationRequest.HasDoor)
                {
                    _setService.Door = await _priceRepository.GetPriceByIdAsync(DOOR_ID);
                }

                int AllCost = _setService.Walls + _setService.Projects + _setService.Geology + _setService.Construction
                            + _setService.Armo + _setService.Seams + _setService.DeliveryDistanceKilometers + _setService.Fundation
                            + _setService.Roof + _setService.FiledWindowArea + _setService.Door;

                _setService.AllCost = AllCost;

                _setService.DateTime = DateTime.Now;
            }

            await _priceRepository.FillDatabaseCalculationCustomerAsync(_setService);

            return _setService.RequestId;    
        }


        // Get a calculation
        public async Task <UserCalculationRequest> GetCalculationCost (Guid guid)
        {
            UserCalculationRequest userCalculationRequest = await _priceRepository.GetCalculationCost(guid);
            return userCalculationRequest;
        }


        // User Contacts Add
        public async Task UserContactsAdd(UserContacts userContacts)
        {

            if (userContacts.NameUser != null)
            {
                _userContacts.NameUser = userContacts.NameUser;
            }

            if (userContacts.PhoneUser != null)
            {
                _userContacts.PhoneUser = userContacts.PhoneUser;
            }

            if (userContacts.UserRequestLists != null)
            {
                _userContacts.UserRequestLists = userContacts.UserRequestLists;
            }

            await _priceRepository.FillDatabaseContactsAsync(_userContacts);
        }


        // Get All Orders
        public async Task <List<UserContacts>> GetAllOrders()
        {
            List<UserContacts> userContacts = await _priceRepository.GetAllUserContacts();
            return userContacts;
        }


        // Get User Contact
        public async Task <UserOrder> GetOrder(int userId)
        {
            List<UserContacts> userContacts = await _priceRepository.GetAllUserContacts();
            UserContacts userContactOne = null;

            foreach (UserContacts userContact in userContacts)
            {
                if (userId == userContact.Id)
                {
                    userContactOne = new UserContacts
                    {
                        NameUser = userContact.NameUser,
                        PhoneUser = userContact.PhoneUser,
                        UserRequestLists = userContact.UserRequestLists
                    };
                    break;
                }
            }

            if (userContactOne == null)
            {
                throw new UserNotFoundException();
            }

            List<Guid> guids = userContactOne.UserRequestLists;
            List<UserCalculationRequest> userCalculationRequests = new List<UserCalculationRequest>();

            foreach (Guid guid in guids)
            {
                UserCalculationRequest userCalculationRequest = await _priceRepository.GetCalculationCost(guid);
                userCalculationRequests.Add(userCalculationRequest);
            }

            var result = new UserOrder
            {
                UserContact = userContactOne,
                UserCalculationRequests = userCalculationRequests
            };
            
            return result;
        }
    }
}

using HauseCalcApi.Models;

namespace HauseCalcApi.Core
{
    public class CalculatorService : ICalculatorService
    {
        private readonly IPriceRepository _priceRepository;
        private readonly SetServiceClient _setService;

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

    public CalculatorService(IPriceRepository priceRepository, SetServiceClient setService)
    {
        _priceRepository = priceRepository;
        _setService = setService;
        }

        public async Task<Guid> SetCalculationClient(SetServiceClientDTO setServiceClients)
        {

            if (setServiceClients.areaHouseSquarMeters <= 0)
            {
                throw new ArgumentException("Еhe house area field is not filled in!");
            }
            else
            {
                _setService.IdGuid = Guid.NewGuid();

                _setService.areaHouseSquarMeters = setServiceClients.areaHouseSquarMeters;

                if (setServiceClients.Walls == true)
                {
                    _setService.Walls = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(SETWALLS_ID);
                }

                if (setServiceClients.Projects == true)
                {
                    _setService.Projects = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(PROJECT_ID);
                }

                if (setServiceClients.Geology == true)
                {
                    _setService.Geology = await _priceRepository.GetPriceByIdAsync(GEOLOGI_ID);
                }

                if (setServiceClients.Geodesy == true)
                {
                    _setService.Geodesy = await _priceRepository.GetPriceByIdAsync(GEODESY_ID);
                }

                if (setServiceClients.Construction == true)
                {
                    _setService.Construction = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(CONSTRUCTION_ID);
                }

                if (setServiceClients.Armo == true)
                {
                    _setService.Armo = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(ARMO_ID);
                }

                if (setServiceClients.Seams == true)
                {
                    _setService.Seams = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(SEAMS_ID);
                }

                if (setServiceClients.DeliveryDistanceKilometers >= 0)
                {
                    _setService.DeliveryDistanceKilometers = setServiceClients.DeliveryDistanceKilometers * await _priceRepository.GetPriceByIdAsync(DELIVERY_ID);
                }

                if (setServiceClients.Fundation == true)
                {
                    _setService.Fundation = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(FUNDATION_ID);
                }

                if (setServiceClients.Roof == true)
                {
                    _setService.Roof = setServiceClients.areaHouseSquarMeters * await _priceRepository.GetPriceByIdAsync(ROOF_ID);
                }

                if (setServiceClients.FiledWindowArea >= 0)
                {
                    _setService.FiledWindowArea = setServiceClients.FiledWindowArea * await _priceRepository.GetPriceByIdAsync(WINDOWS_ID);
                }

                if (setServiceClients.Door == true)
                {
                    _setService.Door = await _priceRepository.GetPriceByIdAsync(DOOR_ID);
                }

                int AllCost = _setService.Walls + _setService.Projects + _setService.Geology + _setService.Construction
                            + _setService.Armo + _setService.Seams + _setService.DeliveryDistanceKilometers + _setService.Fundation
                            + _setService.Roof + _setService.FiledWindowArea + _setService.Door;

                _setService.AllCost = AllCost;
            }

            await _priceRepository.FillDatabaseCalculationCustomerAsync(_setService);

            return _setService.IdGuid;    
        }


        // Get a calculation
        public async Task <SetServiceClient> GetCalculationCost (Guid guid)
        {
            SetServiceClient setServiceClients = await _priceRepository.GetCalculationCost(guid);
            return setServiceClients;
        }
    }
}

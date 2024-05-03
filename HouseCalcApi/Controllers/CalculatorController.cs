using Microsoft.AspNetCore.Mvc;
using HouseCalcApi.Models;
using HouseCalcApi.Core;

namespace HouseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ICalculatorService calculatorService, ILogger<CalculatorController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> RequestHouseCalculation(UserCalculationRequestDTO costService)
        {
            var error = ValidateAreaHouseSquarMetersRequest(costService);
            if (error != null)
            {
                _logger.LogWarning($"The field of AreaHouseSquarMeters has not been found {error}");
                return BadRequest(error);
            }

            Guid calculationClientId = await _calculatorService.UserCalculationRequest(costService);
            return calculationClientId;
        }


        [HttpGet("getCalculation/{externalId}")]
        public async Task<ActionResult<UserCalculationRequest>> GetCalculationCost(Guid externalId)
        {
            UserCalculationRequest resultPriceValue = await _calculatorService.GetCalculationCost(externalId);
            return resultPriceValue;
        }


        private string? ValidateAreaHouseSquarMetersRequest(UserCalculationRequestDTO costService)
        {
            if (costService.AreaHouseSquarMeters == 0)
            {
                return "You didn't fill in the AreaHouseSquarMeters field";
            }

            return null;
        }
    }
}

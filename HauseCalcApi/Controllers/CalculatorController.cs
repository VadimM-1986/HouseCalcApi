using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HauseCalcApi.Models;
using HauseCalcApi.Core;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace HauseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public CalculatorController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }


        [HttpPost]
        public async Task<ActionResult<Guid>> RequestHouseCalculation(UserCalculationRequestDTO costService)
        {
            try
            {
                Guid calculationClientId = await _calculatorService.UserCalculationRequest(costService);
                return calculationClientId;
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpGet("getCalculation/{externalId}")]
        public async Task<ActionResult<UserCalculationRequest>> GetCalculationCost(Guid externalId)
        {
            try
            {
                UserCalculationRequest resultPriceValue = await _calculatorService.GetCalculationCost(externalId);
                return resultPriceValue;
            }
            catch(Exception ex)
            {
                return NotFound("Resource not found");
            }

        }
    }
}

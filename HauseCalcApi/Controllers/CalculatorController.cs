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
        public async Task<ActionResult<Guid>> RequestHouseCalculation(SetServiceClientDTO costService)
        {
            Guid calculationClientId = await _calculatorService.SetCalculationClient(costService);
            return calculationClientId;
        }


        [HttpGet("getCalculation/{idGuid}")]
        public async Task<ActionResult<SetServiceClient>> GetCalculationCost(Guid idGuid)
        {
            SetServiceClient resultPriceValue = await _calculatorService.GetCalculationCost(idGuid);
            return resultPriceValue;
        }
    }
}

﻿using System;
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
            var error = ValidateAreaHouseSquarMetersRequest(costService);
            if (error != null)
            {
                Console.WriteLine(error);
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
                return "Not all data is filled in";
            }

            return null;
        }
    }
}

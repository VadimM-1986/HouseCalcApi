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


        [HttpGet("walls/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetWallsCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetWallsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("projects/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetProjectsCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetProjectsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("geology/")]
        public async Task<ActionResult<int>> GetGeologyCost()
        {
                var resultPriceValue = await _calculatorService.GetGeologyCost();
                return resultPriceValue;
        }

        [HttpGet("geodesy/")]
        public async Task<ActionResult<int>> GetGeodesyCost()
        {
                var resultPriceValue = await _calculatorService.GetGeodesyCost();
                return resultPriceValue;
        }

        [HttpGet("construction/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetConstructionCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetConstructionCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("armo/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetArmoCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetArmoCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("seams/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetSeamsCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetSeamsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("delivery/{distanceKilometer}")]
        public async Task<ActionResult<int>> GetDeliveryCost(int distanceKilometer)
        {
            if (distanceKilometer >= 0)
            {
                var resultPriceValue = await _calculatorService.GetDeliveryCost(distanceKilometer);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("fundation/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetFundationCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetFundationCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("roof/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetRoofCost(int areaHouseSquarMeters)
        {
            if (areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetRoofCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("windows/{filedWindowArea}")]
        public async Task<ActionResult<int>> GetWindowsCost(int filedWindowArea)
        {
            if (filedWindowArea >= 0)
            {
                var resultPriceValue = await _calculatorService.GetWindowsCost(filedWindowArea);
                return resultPriceValue;
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("door/")]
        public async Task<ActionResult<int>> GetDoorCost()
        {
                var resultPriceValue = await _calculatorService.GetDoorCost();
                return resultPriceValue;
        }
    }
}

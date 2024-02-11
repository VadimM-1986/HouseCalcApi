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


        [HttpGet("walls/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetWallsCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getwallscost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetWallsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("projects/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetProjectsCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getprojectscost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetProjectsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("geology/{id}")]
        public async Task<ActionResult<int>> GetGeologyCost(string id)
        {
            if (id == "getgeologycost")
            {
                var resultPriceValue = await _calculatorService.GetGeologyCost();
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("geodesy/{id}")]
        public async Task<ActionResult<int>> GetGeodesyCost(string id)
        {
            if (id == "getgeodesycost")
            {
                var resultPriceValue = await _calculatorService.GetGeodesyCost();
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("construction/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetConstructionCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getconstructioncost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetConstructionCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("armo/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetArmoCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getarmocost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetArmoCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("seams/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetSeamsCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getseamscost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetSeamsCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("delivery/{id}/{distanceKilometer}")]
        public async Task<ActionResult<int>> GetDeliveryCost(string id, int distanceKilometer)
        {
            if (id == "getdeliverycost" && distanceKilometer >= 0)
            {
                var resultPriceValue = await _calculatorService.GetDeliveryCost(distanceKilometer);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("fundation/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetFundationCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getfundationcost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetFundationCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("roof/{id}/{areaHouseSquarMeters}")]
        public async Task<ActionResult<int>> GetRoofCost(string id, int areaHouseSquarMeters)
        {
            if (id == "getroofcost" && areaHouseSquarMeters >= 0)
            {
                var resultPriceValue = await _calculatorService.GetRoofCost(areaHouseSquarMeters);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("windows/{id}/{filedWindowArea}")]
        public async Task<ActionResult<int>> GetWindowsCost(string id, int filedWindowArea)
        {
            if (id == "getwindowscost" && filedWindowArea >= 0)
            {
                var resultPriceValue = await _calculatorService.GetWindowsCost(filedWindowArea);
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet("door/{id}")]
        public async Task<ActionResult<int>> GetDoorCost(string id)
        {
            if (id == "getdoorcost")
            {
                var resultPriceValue = await _calculatorService.GetDoorCost();
                return resultPriceValue;
            }
            else
            {
                return NotFound();
            }
        }





        //[HttpPost]
        // public async Task<ActionResult<int>> PostGetWallsCost(string id, int areaHouseSquarMeters)
        // {
        //     if (id == "getwallscost")
        //     {
        //         var resultPriceValue = await _calculatorService.GetWallsCost(areaHouseSquarMeters);
        //         return resultPriceValue;
        //     }
        //     else
        //     {
        //         return NotFound();
        //     }
        // }

        //[HttpPut("{id}")]
        //public async Task<IActionResult> UpdateGetPrice(string id, int transmittedHouseParameters)
        //{
        //    if (id == "getwallscost")
        //    {
        //        int resultCost = await _calculatorService.GetWallsCost(transmittedHouseParameters);
        //        return CreatedAtAction(nameof(GetPrice), new { id, resultCost });
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<PriceDTO>>> GetPrices()
        //{
        //    return await _calculatorService.GetProjectsCost();
        //    return await _context.Prices.Select(x => PriceToDTO(x)).ToListAsync();
        //}

        //private static PriceDTO PriceDTO(Price price) =>
        //   new PriceDTO
        //   {
        //       Id = price.Id,
        //       Name = price.Name,
        //       Value = price.Value
        //   };

    }
}

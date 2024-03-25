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
using Microsoft.AspNetCore.Http.HttpResults;
using static System.Runtime.InteropServices.JavaScript.JSType;
using NuGet.Protocol.Core.Types;

namespace HauseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;

        public UserController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }


        [HttpPost]
        public async Task<ActionResult> UserContactsAdd(UserContactDTO userContactDTO)
        {
            var error = ValidateUserRequest(userContactDTO);
            if (error != null)
            {
                Console.WriteLine(error);
                return BadRequest(error);
            }

            int? userContactId = await _calculatorService.UserContactsAdd(userContactDTO);

            return Ok(userContactId);
        }


        private string? ValidateUserRequest(UserContactDTO dto)
        {
            if (dto == null)
            {
                return "Not all data is filled in";
            }

            return null;
        }
    }
}

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
        public async Task<ActionResult> UserContactsAdd(UserContactsDTO userContactsDTO)
        {
            var error = ValidateUserRequest(userContactsDTO);
            if (error != null)
            {
                Console.WriteLine(error);
                return BadRequest(error);
            }

            var userContacts = new UserContact
            {
                NameUser = userContactsDTO.NameUser,
                PhoneUser = userContactsDTO.PhoneUser,
                UserRequestLists = userContactsDTO.UserRequestLists
            };

            int? Id = await _calculatorService.UserContactsAdd(userContacts);
            return Ok(Id);
        }


        private string? ValidateUserRequest(UserContactsDTO dto)
        {
            if (dto == null)
            {
                return "Not all data is filled in";
            }

            return null;
        }
    }
}

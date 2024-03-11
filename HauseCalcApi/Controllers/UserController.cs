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
    public class UserController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        public UserController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpPost]
        public ActionResult UserContacts(UserContactsDTO userContactsDTO)
        {
            var userContacts = new UserContacts
            {
                NameUser = userContactsDTO.NameUser,
                PhoneUser = userContactsDTO.PhoneUser,
                UserRequestLists = userContactsDTO.UserRequestLists
            };
            _calculatorService.UserContactsAdd(userContacts);
            return Ok();
        }
    }
}

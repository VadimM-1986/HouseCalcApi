using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using HauseCalcApi.Core;
using HauseCalcApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HauseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : Controller
    {
        
        private readonly ICalculatorService _calculatorService;

        public AdminController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }


        [HttpGet("getUsersOrders")]
        public async Task <ActionResult<UserContactsResponse>> GetAllUsersOrders()
        {

                List<UserContacts> resultAllUsersOrders = await _calculatorService.GetAllOrders();

                var response = new UserContactsResponse
                {
                    UserContacts = resultAllUsersOrders
                };

                return Ok(response);
        }


        [HttpGet("userOrders/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            try
            {
                UserOrder userOrder = await _calculatorService.GetOrder(userId);
                return Ok(userOrder);
            }
            catch (Exception ex)
            {
                return NotFound("User not found");
            }
        }
    }
}


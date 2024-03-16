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
        private readonly ILogger<AdminController> _logger;

        public AdminController(ICalculatorService calculatorService, ILogger<AdminController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
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
                throw new UserNotFoundException
                UserOrder userOrder = await _calculatorService.GetOrder(userId);
                return Ok(userOrder);
            }
            catch (UserNotFoundException _)
            {
                Console.WriteLine($"User not found {userId}");
                _logger.LogWarning($"User not found {userId}");
                return NotFound("User not found");

            }
        }
    }
}


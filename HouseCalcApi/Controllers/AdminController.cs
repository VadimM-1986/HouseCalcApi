using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using HouseCalcApi.Core;
using HouseCalcApi.Models;
using Microsoft.AspNetCore.Mvc;


namespace HouseCalcApi.Controllers
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

                List<UserContact> resultAllUsersOrders = await _calculatorService.GetAllOrders();

                var response = new UserContactsResponse
                {
                    UserContacts = resultAllUsersOrders
                };

                return Ok(response);
        }


        [HttpGet("userOrders/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
                UserOrder userOrder = await _calculatorService.GetOrder(userId);
                return Ok(userOrder);
        }

    }
}


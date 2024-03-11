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

        [HttpGet("getUsersOrdersAll")]
        public async Task <ActionResult <List<UserContacts>>> GetAllUsersOrders()
        {
            try
            {
                List<UserContacts> resultAllUsersOrders = await _calculatorService.GetAllOrders();
                return Ok(resultAllUsersOrders);
            }
            catch (Exception ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
        }

        [HttpGet("userOrders/{userId}")]
        public async Task<IActionResult> GetUserOrders(int userId)
        {
            UserOrder userOrder = await _calculatorService.GetOrder(userId);
            return Ok(userOrder);
        }
    }
}
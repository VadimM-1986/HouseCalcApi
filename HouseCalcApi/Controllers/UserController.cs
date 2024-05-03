using Microsoft.AspNetCore.Mvc;
using HouseCalcApi.Models;
using HouseCalcApi.Core;

namespace HouseCalcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ICalculatorService _calculatorService;
        private readonly ILogger<UserController> _logger;

        public UserController(ICalculatorService calculatorService, ILogger<UserController> logger)
        {
            _calculatorService = calculatorService;
            _logger = logger;
        }


        [HttpPost]
        public async Task<ActionResult> UserContactsAdd(UserContactDTO userContactDTO)
        {
            var error = ValidateUserRequest(userContactDTO);
            if (error != null)
            {
                _logger.LogWarning(error);
                return BadRequest(error);
            }

            int? userContactId = await _calculatorService.UserContactsAdd(userContactDTO);

            return Ok(userContactId);
        }


        private string? ValidateUserRequest(UserContactDTO dto)
        {
            string errorAnswerMessage = "You haven't filled out these fields: ";

            if (dto != null)
            {          
                if(String.IsNullOrEmpty(dto.NameUser))
                {
                    errorAnswerMessage += "User name. ";
                }

                else if(String.IsNullOrEmpty(dto.PhoneUser))
                {
                    errorAnswerMessage += "User phone. ";
                }

                else if (dto.UserRequestLists == null)
                {
                    errorAnswerMessage += "User request lists.";
                    
                }

                return errorAnswerMessage;
            }
            return null;
        }
    }
}

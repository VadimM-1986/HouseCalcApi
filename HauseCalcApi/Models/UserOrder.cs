using System.ComponentModel.DataAnnotations;
using HauseCalcApi.Models;

namespace HauseCalcApi.Models
{
    public class UserOrder
    {
        public UserContact? UserContact { get; set; }
        public List<UserCalculationRequest>? UserCalculationRequests { get; set; }
    }
}

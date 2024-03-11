using System.ComponentModel.DataAnnotations;
using HauseCalcApi.Models;

namespace HauseCalcApi.Models
{
    public class UserOrder
    {
        public UserContacts? UserContact { get; set; }
        public List<UserCalculationRequest>? UserCalculationRequests { get; set; }
    }
}

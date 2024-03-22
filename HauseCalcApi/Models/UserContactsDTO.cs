using System.ComponentModel.DataAnnotations;

namespace HauseCalcApi.Models
{
    public class UserContactsDTO
    {
        public string? NameUser { get; set; }
        public string? PhoneUser { get; set; }
        public List<string> UserRequestLists { get; set; } = new();
    }
}
using System.ComponentModel.DataAnnotations;

namespace HouseCalcApi.Models
{
    public class UserContact
    {
        [Key]
        public int Id { get; set; }
        public string? NameUser { get; set; }
        public string? PhoneUser { get; set; }
    }
}

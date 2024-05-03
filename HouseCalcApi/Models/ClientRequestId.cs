using System.ComponentModel.DataAnnotations;

namespace HouseCalcApi.Models
{
    public class ClientRequestId
    {
        [Key]
        public int Id { get; set; }
        public int ContactID { get; set; }
        public Guid RequestID { get; set; }
    }
}
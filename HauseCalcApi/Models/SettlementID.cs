using System.ComponentModel.DataAnnotations;

namespace HauseCalcApi.Models
{
    public class SettlementID
    {
        [Key]
        public int Id { get; set; }
        public int ContactID { get; set; }
        public Guid RequestID { get; set; }
    }
}
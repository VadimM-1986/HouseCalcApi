using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace HauseCalcApi.Models
{
    public class UserCalculationRequest
    {
        [Key]
        public int Id { get; set; }
        public Guid RequestId { get; set; }
        public int AreaHouseSquarMeters { get; set; }
        public int Walls { get; set; }
        public int Projects { get; set; }
        public int Geology { get; set; }
        public int Geodesy { get; set; }
        public int Construction { get; set; }
        public int Armo { get; set; }
        public int Seams { get; set; }
        public int DeliveryDistanceKilometers { get; set; }
        public int Fundation { get; set; }
        public int Roof { get; set; }
        public int FiledWindowArea { get; set; }
        public int Door { get; set; }
        public int AllCost { get; set; }
        public DateTime DateTime { get; set; }
    }
}

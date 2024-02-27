using System.ComponentModel.DataAnnotations;

namespace HauseCalcApi.Models
{
    public class SetServiceClient
    {
        [Key]
        public int Id { get; set; }
        public Guid IdGuid { get; set; }
        public int areaHouseSquarMeters { get; set; }
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
    }
}

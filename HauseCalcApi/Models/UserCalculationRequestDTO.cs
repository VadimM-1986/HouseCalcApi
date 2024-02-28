namespace HauseCalcApi.Models
{
    public class UserCalculationRequestDTO
    {
            public int AreaHouseSquarMeters { get; set; }
            public bool HasWalls { get; set; }
            public bool HasProjects { get; set; }
            public bool HasGeology { get; set; }
            public bool HasGeodesy { get; set; }
            public bool HasConstruction { get; set; }
            public bool HasArmo { get; set; }
            public bool HasSeams { get; set; }
            public int DeliveryDistanceKilometers { get; set; }
            public bool HasFundation { get; set; }
            public bool HasRoof { get; set; }
            public int FiledWindowArea { get; set; }
            public bool HasDoor { get; set; }       
    }
}


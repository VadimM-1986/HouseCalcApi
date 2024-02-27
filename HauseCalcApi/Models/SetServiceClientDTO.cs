namespace HauseCalcApi.Models
{
    public class SetServiceClientDTO
    {
            public int areaHouseSquarMeters { get; set; }
            public bool Walls { get; set; }
            public bool Projects { get; set; }
            public bool Geology { get; set; }
            public bool Geodesy { get; set; }
            public bool Construction { get; set; }
            public bool Armo { get; set; }
            public bool Seams { get; set; }
            public int DeliveryDistanceKilometers { get; set; }
            public bool Fundation { get; set; }
            public bool Roof { get; set; }
            public int FiledWindowArea { get; set; }
            public bool Door { get; set; }       
    }
}


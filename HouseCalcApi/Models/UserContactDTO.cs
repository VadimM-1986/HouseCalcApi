﻿namespace HouseCalcApi.Models
{
    public class UserContactDTO
    {
        public string? NameUser { get; set; }
        public string? PhoneUser { get; set; }
        public List<Guid> UserRequestLists { get; set; } = new();
    }
}
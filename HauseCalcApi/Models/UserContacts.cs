﻿using Swashbuckle.AspNetCore.SwaggerGen;
using System.ComponentModel.DataAnnotations;

namespace HauseCalcApi.Models
{
    public class UserContacts
    {
        [Key]
        public int Id { get; set; }
        public string? NameUser { get; set; }
        public string? PhoneUser { get; set; }
        public List<Guid> UserRequestLists { get; set; } = new();
    }
}

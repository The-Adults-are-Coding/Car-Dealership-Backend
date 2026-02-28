using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using Microsoft.AspNetCore.Identity;

namespace CarDealerShipBackend.Domain.Entities

{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string National_ID {  get; set; }= string.Empty;
        public string Address { get; set; } = string.Empty;
        public string occupation { get; set; } = string.Empty;
        public string? DeviceToken { get; set; }
        public double balance { get; set; }
    }
}
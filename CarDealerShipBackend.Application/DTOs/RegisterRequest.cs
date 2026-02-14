using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.DTOs
{
    public class RegisterRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }

        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
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
        public string ?Address { get; set; }
        public string ?National_ID { get; set; }
        public string ?occupation { get; set; }
        public string ?PhoneNumber { get; set; }
    }
}
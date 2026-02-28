using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.DTOs
{
    public class UpdateTokenRequest
    {
        public required string DeviceToken { get; set; }
    }
}

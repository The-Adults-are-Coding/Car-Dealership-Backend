using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealerShipBackend.Application.Interfaces
{
    public interface INotificationService
    {
        Task SendNotificationAsync(string deviceToken, string title, string body);
    }
}

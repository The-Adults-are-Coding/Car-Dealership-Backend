using CarDealerShipBackend.Application.Interfaces;
using CarDealerShipBackend.Domain.Entities; 
using CarDealerShipBackend.Infrastructure.Data;
using Microsoft.EntityFrameworkCore; 
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CarDealerShipBackend.Infrastructure.BackgroundServices
{
    public class PaymentNotificationScheduler : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public PaymentNotificationScheduler(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                using (var scope = _serviceProvider.CreateScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                    var notificationService = scope.ServiceProvider.GetRequiredService<INotificationService>();

                    var today = DateTime.Today;

                    var paymentsToNotify = await dbContext.InstallmentPayments
                        .Where(p => p.ScheduledDate.Date == today)
                        .Include(p => p.SalesContract) 
                            .ThenInclude(c => c.Customer) 
                        .ToListAsync();

                    foreach (var payment in paymentsToNotify)
                    {
                        string deviceToken = payment.SalesContract.Customer.DeviceToken;

                        if (!string.IsNullOrEmpty(deviceToken))
                        {
                            string title = "Payment Due!";
                            string body = $"Your payment of {payment.ScheduledAmount:C} is due today.";

                            await notificationService.SendNotificationAsync(deviceToken, title, body);
                        }
                    }
                }

                await Task.Delay(TimeSpan.FromHours(24), stoppingToken);
            }
        }
    }
}
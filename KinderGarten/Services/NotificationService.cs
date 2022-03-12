using KinderGarten.Interfaces;
using Microsoft.AspNetCore.SignalR;
using KinderGarten.Hubs;
using System.Threading.Tasks;

namespace KinderGarten.Services
{
    /// <summary>
    /// Used for server side notifications (SignalR)
    /// </summary>
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public async Task SendNotification(string message)
        {
            await hubContext.Clients.All.SendAsync("OnMessageReceived", message);
        }
    }
}

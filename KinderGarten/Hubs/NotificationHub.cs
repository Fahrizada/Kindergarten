using Microsoft.AspNetCore.SignalR;

namespace KinderGarten.Hubs
{
    public class NotificationHub : Hub
    {
        public async void SendNotification(string message)
        {
            await Clients.Others.SendAsync("OnMessageReceived", message);
        }
    }
}

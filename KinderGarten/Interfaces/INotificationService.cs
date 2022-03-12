using System.Threading.Tasks;

namespace KinderGarten.Interfaces
{
    public interface INotificationService
    {
        Task SendNotification(string message);
    }
}

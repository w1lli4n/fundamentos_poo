using System.Collections.Generic;
using System.Linq;

namespace Balta.NotificationContext
{
    public abstract class Notifiable
    {
        public Notifiable()
        {
            Notifications = new List<Notification>();    
        }

        public List<Notification> Notifications { get; set; }
        public bool IsInvalid => Notifications.Any();

        public void AddNotification(Notification notification)
        {
            Notifications.Add(notification);
        }
        public void AddRangeNotification(IEnumerable<Notification> notification)
        {
            Notifications.AddRange(notification);
        }
    }
}
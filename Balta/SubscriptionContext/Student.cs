using Balta.SharedContext;
using Balta.NotificationContext;
using System.Collections.Generic;

namespace Balta.SubscriptionContext
{
    public class Student : Base
    {
        public Student()
        {
            SubscriptionStudent = new List<Subscription>();
        }
        public User UserStudent { get; set; }   
        public string Pass { get; set; }

        public List<Subscription> SubscriptionStudent { get; set; }

        public bool IsPremium => SubscriptionStudent.Any(x => !x.IsInactive);

        public void CreateSubscription(Subscription subscription)
        {
            if (IsPremium)
            {
                AddNotification(new Notification("Premium", "Não pode ter duas assinaturas simultaneas"));
            } 
            else
            {
                SubscriptionStudent.Add(subscription);
            }
        }
    }
}
using Balta.SharedContext;

namespace Balta.SubscriptionContext
{
    public class Subscription : Base
    {
        public Plan PlanSubscription { get; set; }
        public DateTime? EndDate { get; set; }

        public bool IsInactive {
            get
            {
                return EndDate <= DateTime.Now;
            }
        }
    }
}
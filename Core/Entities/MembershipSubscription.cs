using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class MembershipSubscription : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public string Status { get; set; }
        public int MemberID { get; set; } // ==> FK
        public Member Member { get; set; } // ==> Navigation Property
        public int MembershipPlanID { get; set; } // ==> FK
        public MembershipPlan MembershipPlan { get; set; } // ==> Navigation Property
        public List<Payment> Payments { get; set; } = new();
    }
}

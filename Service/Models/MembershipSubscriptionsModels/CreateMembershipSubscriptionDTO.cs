using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.MembershipSubscriptionsModels
{
    public class CreateMembershipSubscriptionDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public string Status { get; set; }
        public int MemberID { get; set; }
        public int MembershipPlanID { get; set; } 

    }
}

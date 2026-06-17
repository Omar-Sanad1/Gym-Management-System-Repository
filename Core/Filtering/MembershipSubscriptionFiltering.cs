using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class MembershipSubscriptionFiltering
    {
        public int? MemberID { get; set; } 
        public int? MembershipPlanID { get; set; } 
        public string? Status { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending { get; set; }
    }
}

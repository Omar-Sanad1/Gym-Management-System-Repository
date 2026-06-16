using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class MembershipPlanFiltering
    {
        public string? PlanName { get; set; }
        public int? Duration { get; set; }
        public decimal? Fee { get; set; }
        public string? Benefits { get; set; }

    }
}

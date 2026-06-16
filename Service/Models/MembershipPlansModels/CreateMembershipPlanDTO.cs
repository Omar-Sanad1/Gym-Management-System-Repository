using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.MembershipPlansModels
{
    public class CreateMembershipPlanDTO
    {
        public string PlanName { get; set; }
        public int Duration { get; set; }
        public decimal Fee { get; set; }
        public string Benefits { get; set; }
        public string AccessLevel { get; set; }
    }
}

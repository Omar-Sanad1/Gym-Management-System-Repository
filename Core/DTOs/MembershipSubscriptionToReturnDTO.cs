using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class MembershipSubscriptionToReturnDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool isActive { get; set; }
        public string Status { get; set; }
        public string MemberName { get; set; } 
        public string PlanName { get; set; } 
    }
}

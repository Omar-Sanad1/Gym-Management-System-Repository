using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class MemberFiltering
    {
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PhoneNumber { get; set; }
        public int? BranchID { get; set; }
        public int? TrainerID { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending { get; set; }

    }
}

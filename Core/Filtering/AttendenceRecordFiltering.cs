using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class AttendenceRecordFiltering
    {
        public string? Category { get; set; }
        public string? AttendanceType { get; set; }
        public int? FitnessClassID { get; set; }
        public int? MemberID { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending{ get; set; }

    }
}

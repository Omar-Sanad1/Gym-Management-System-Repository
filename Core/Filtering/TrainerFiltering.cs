using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class TrainerFiltering
    {
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public int? BranchID { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending { get; set; }

    }
}

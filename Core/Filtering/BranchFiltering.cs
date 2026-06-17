using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class BranchFiltering
    {
        public string? BranchName { get; set; }
        public string? Location { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending { get; set; }
    }
}

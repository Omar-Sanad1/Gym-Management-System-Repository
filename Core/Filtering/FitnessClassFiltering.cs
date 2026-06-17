using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class FitnessClassFiltering
    {
        public string? ClassName { get; set; }
        public string? Category { get; set; }
        public string? AssignedTrainer { get; set; }
        public int? BranchID { get; set; }

        // Sorting
        public string? SortBy { get; set; }
        public bool isDescending { get; set; }



    }
}

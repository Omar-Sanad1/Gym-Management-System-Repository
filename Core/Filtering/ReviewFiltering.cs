using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Filtering
{
    public class ReviewFiltering
    {
        public DateTime? ReviewDate { get; set; }
        public int? FitnessClassID { get; set; } 
        public int? TrainerID { get; set; } 
        public int? MemberID { get; set; } 
    }
}

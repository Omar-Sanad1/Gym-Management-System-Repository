using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Member_FitnessClass_Enroll
    {
        public int MemberID { get; set; } // ==> FK
        public Member Member { get; set; } // ==> Navigation Property
        public int FitnessClassID { get; set; } // ==> FK
        public FitnessClass FitnessClass { get; set; } // ==> Navigation Property
    }
}

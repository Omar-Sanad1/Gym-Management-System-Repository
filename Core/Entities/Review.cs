using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Review : BaseEntity
    {
        public DateTime ReviewDate { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int FitnessClassID { get; set; } // ==> FK
        public FitnessClass FitnessClass { get; set; } // ==> Navigation Property
        public int TrainerID { get; set; } // ==> FK
        public Trainer Trainer { get; set; } // ==> Navigation Property
        public int MemberID { get; set; } // ==> FK
        public Member Member { get; set; } // ==> Navigation Property
    }
}

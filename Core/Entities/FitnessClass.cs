using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class FitnessClass : BaseEntity
    {
        public string ClassName { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public DateTime Schedule { get; set; }
        public int Duration { get; set; }
        public int MaximumCapacity { get; set; }
        public string AvailabilityStatus { get; set; }
        public string AssignedTrainer { get; set; }
        public int TrainerID { get; set; } // ==> FK
        public Trainer Trainer { get; set; } // ==> Navigation Property
        public int BranchID { get; set; } // ==> FK
        public Branch Branch { get; set; } // ==> Navigation Property
        public List<AttendenceRecord> AttendenceRecords { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<Member_FitnessClass_Enroll> Member_FitnessClasses { get; set; } = new();

    }
}

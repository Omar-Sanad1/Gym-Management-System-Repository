using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Member : BaseEntity
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PaswordHash { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string Gender { get; set; }
        public string AccountStatus { get; set; }
        public string EmergencyContactInformation { get; set; }
        public int TrainerID { get; set; } // ==> FK
        public Trainer Trainer { get; set; } // ==> Navigation Property
        public int BranchID { get; set; } // ==> FK
        public Branch Branch { get; set; } // ==> Navigation Property
        public List<AttendenceRecord> AttendenceRecords { get; set; } = new();
        public List<Review> Reviews { get; set; } = new();
        public List<MembershipSubscription> MembershipSubscriptions { get; set; } = new();
        public List<Member_FitnessClass_Enroll> Member_FitnessClasses { get; set; } = new();

    }
}

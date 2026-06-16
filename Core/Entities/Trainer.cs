using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Trainer : BaseEntity
    {
        public string FullName { get; set; }
        public string Specialization { get; set; }
        public int YearsOfExperience { get; set; }
        public string Certifications { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public string PasswordHash { get; set; }
        public DateTime EmploymentDate { get; set; }
        public string SalaryInformation { get; set; }
        public string EmploymentStatus { get; set; }
        public int BranchID { get; set; } // ==> FK
        public Branch Branch { get; set; } // ==> Navigation Property
        public List<Review> Reviews { get; set; } = new();
        public List<FitnessClass> FitnessClasses { get; set; } = new();
        public List<Member> Members { get; set; } = new();

    }
}

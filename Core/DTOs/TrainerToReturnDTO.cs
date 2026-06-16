using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class TrainerToReturnDTO
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
        public int BranchID { get; set; } 
        
    }
}

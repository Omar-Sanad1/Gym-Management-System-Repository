using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.DTOs
{
    public class MemberToReturnDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegisterationDate { get; set; }
        public string Gender { get; set; }
        public string AccountStatus { get; set; }
        public string? EmergencyContactInformation { get; set; }
        public string TrainerName { get; set; } 
        public int BranchID { get; set; }
        public string Token { get; set; }
    }
}

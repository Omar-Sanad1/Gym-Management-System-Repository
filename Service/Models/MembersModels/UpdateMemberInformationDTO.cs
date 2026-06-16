using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models.MembersModels
{
    public class UpdateMemberInformationDTO
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string AccountStatus { get; set; }
        public string EmergencyContactInformation { get; set; }


    }
}

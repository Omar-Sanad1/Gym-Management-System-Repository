using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    public class RegisterMemberModel
    {
        [Required,StringLength(200)]
        public string FullName { get; set; }
        [Required, StringLength(200)]
        public string EmailAddress { get; set; }
        [Required, StringLength(200)]
        public string PhoneNumber { get; set; }
        [Required, StringLength(200)]
        public string Password { get; set; }
        [Required, StringLength(50)]
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string EmergencyContactInformation { get; set; }
        public int BranchID { get; set; }
        public int TrainerID { get; set; }
    }
}

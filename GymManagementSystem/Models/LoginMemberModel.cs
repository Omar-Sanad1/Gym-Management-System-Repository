using System.ComponentModel.DataAnnotations;

namespace GymManagementSystem.Models
{
    public class LoginMemberModel
    {
        [Required]
        public string EmailAddress { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

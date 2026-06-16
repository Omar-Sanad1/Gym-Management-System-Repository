using Core.DTOs;
using GymManagementSystem.Models;

namespace GymManagementSystem.Services
{
    public interface IAuthService
    {
        public Task<MemberToReturnDTO> RegisterMemberAsync(RegisterMemberModel registerMember);
        public Task<MemberToReturnDTO> LoginMemberAsync(LoginMemberModel loginMember);



    }
}

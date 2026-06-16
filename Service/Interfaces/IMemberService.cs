using Core.DTOs;
using Core.Entities;
using Service.Models.MembersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMemberService
    {
        public Task<IEnumerable<MemberToReturnDTO>> GetAllMembersAsync();
        public Task<IEnumerable<MemberToReturnDTO>> GetAllMembersPagedAsync(int pageNumber, int pageSize);
        public int GetMembersCount();

        // Filtering
        public IEnumerable<MemberToReturnDTO> GetAllMembersFiltered(Func<Member, bool> Filter);
        public Task<MemberToReturnDTO> GetMemberByIDAsync(int memberId);
        public Task<MemberToReturnDTO> UpdateMemberInformationAsync(int memberId, UpdateMemberInformationDTO updateMemberInformation);
        public Task DeleteMemberAsync(int memberId);
    }
}

using Core.DTOs;
using Core.Entities;
using Service.Models.MembershipPlansModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMembershipPlanService
    {
        public Task<IEnumerable<MembershipPlanToReturnDTO>> GetAllMembershipPlansAsync();
        public Task<IEnumerable<MembershipPlanToReturnDTO>> GetAllMembershipPlansPagedAsync(int pageNumber, int pageSize);
        public IEnumerable<MembershipPlanToReturnDTO> GetAllMembershipPlansFiltered(Func<MembershipPlan, bool> Filter);
        public Task<MembershipPlanToReturnDTO> GetMembershipPlanByIDAsync(int membershipPlanId);
        public int GetMembershipPlansCount();
        public Task<MembershipPlanToReturnDTO> CreateNewMembershipPlanAsync(CreateMembershipPlanDTO createMembershipPlan);
        public Task<MembershipPlanToReturnDTO> UpdateMembershipPlanInformationAsync(int membershipPlanId, UpdateMembershipPlanInformation updateMembershipPlan);
        public Task DeleteMembershipPlanByIDAsync(int membershipPlanId);
    }
}

using Core.DTOs;
using Core.Entities;
using Service.Models.MembershipSubscriptionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IMembershipSubscriptionService
    {
        public Task<IEnumerable<MembershipSubscriptionToReturnDTO>> GetAllMembershipSubscriptionsAsync();
        public Task<IEnumerable<MembershipSubscriptionToReturnDTO>> GetAllMembershipSubscriptionsPagedAsync(int pageNumber, int pageSize);
        public IEnumerable<MembershipSubscriptionToReturnDTO> GetAllMembershipSubscriptionsFiltered(Func<MembershipSubscription, bool> Filter);
        public Task<MembershipSubscriptionToReturnDTO> GetMembershipSubscriptionByIDAsync(int membershipSubscriptionId);
        public int GetMembershipSubscriptionsCount();
        public Task<MembershipSubscriptionToReturnDTO> CreateNewMembershipSubscriptionAsync(CreateMembershipSubscriptionDTO createMembershipSubscription);
        public Task<MembershipSubscriptionToReturnDTO> UpdateMembershipSubscriptionInformationAsync(int membershipSubscriptionId , UpdateMembershipSubscriptionInformationDTO updateMembershipSubscriptionInformation);
        public Task DeleteMembershipSubscriptionByIDAsync(int membershipSubscriptionId);
    }
}

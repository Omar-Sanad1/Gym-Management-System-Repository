using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.Interfaces;
using Service.Models.MembershipSubscriptionsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MembershipSubscriptionService : IMembershipSubscriptionService
    {
        private readonly GymManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public MembershipSubscriptionService(GymManagementSystemDbContext dbContext , IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<MembershipSubscriptionToReturnDTO>> GetAllMembershipSubscriptionsAsync()
        {
            var membershipSubscriptions = await _dbContext.MembershipSubscriptions.ToListAsync();

            return _mapper.Map<IEnumerable<MembershipSubscription>, IEnumerable<MembershipSubscriptionToReturnDTO>>(membershipSubscriptions);
        }

        public IEnumerable<MembershipSubscriptionToReturnDTO> GetAllMembershipSubscriptionsFiltered(Func<MembershipSubscription, bool> Filter)
        {
            var membershipSubscriptionsFiltered = _dbContext.Set<MembershipSubscription>()
                                                  .Where(Filter)
                                                  .ToList();
            return _mapper.Map<IEnumerable<MembershipSubscription>, IEnumerable<MembershipSubscriptionToReturnDTO>>(membershipSubscriptionsFiltered);

        }

        public async Task<IEnumerable<MembershipSubscriptionToReturnDTO>> GetAllMembershipSubscriptionsPagedAsync(int pageNumber, int pageSize)
        {
            var membershipSubscriptionsPaged = await _dbContext.Set<MembershipSubscription>()
                                               .Skip((pageNumber - 1) * pageSize)
                                               .Take(pageSize)
                                               .ToListAsync();
            return _mapper.Map<IEnumerable<MembershipSubscription>, IEnumerable<MembershipSubscriptionToReturnDTO>>(membershipSubscriptionsPaged);
        }

        public int GetMembershipSubscriptionsCount()
        {
            return _dbContext.Set<MembershipSubscription>()
                   .Count();
        }


        public async Task<MembershipSubscriptionToReturnDTO> GetMembershipSubscriptionByIDAsync(int membershipSubscriptionId)
        {
            var specifiedMembershipSubscription = await _dbContext.MembershipSubscriptions
                                                  .FirstOrDefaultAsync(m => m.ID == membershipSubscriptionId);
            if (specifiedMembershipSubscription is null)
                throw new ValidationException("This membership subscription isn't exist");

            return _mapper.Map<MembershipSubscription, MembershipSubscriptionToReturnDTO>(specifiedMembershipSubscription);

        }

        public async Task<MembershipSubscriptionToReturnDTO> CreateNewMembershipSubscriptionAsync(CreateMembershipSubscriptionDTO createMembershipSubscription)
        {
            var validStatuses = new[] { "Active" , "Inactive" };
            if (!validStatuses.Contains(createMembershipSubscription.Status))
                throw new ValidationException("This status isn;t valid.Valid statuses(Active , Inactive)");

            var membershipSubscription = new MembershipSubscription
            {
                StartDate = createMembershipSubscription.StartDate,
                EndDate = createMembershipSubscription.EndDate,
                isActive = createMembershipSubscription.isActive,
                Status = createMembershipSubscription.Status,
                MemberID = createMembershipSubscription.MemberID,
                MembershipPlanID = createMembershipSubscription.MembershipPlanID
            };

            await _dbContext.MembershipSubscriptions.AddAsync(membershipSubscription);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MembershipSubscription, MembershipSubscriptionToReturnDTO>(membershipSubscription);
        }

        public async Task DeleteMembershipSubscriptionByIDAsync(int membershipSubscriptionId)
        {
            var specifiedMembershipSubscription = await _dbContext.MembershipSubscriptions
                                                  .FirstOrDefaultAsync(m => m.ID == membershipSubscriptionId);
            if (specifiedMembershipSubscription is null)
                throw new ValidationException("This membership subscription isn't exist");

            _dbContext.MembershipSubscriptions.Remove(specifiedMembershipSubscription);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<MembershipSubscriptionToReturnDTO> UpdateMembershipSubscriptionInformationAsync(int membershipSubscriptionId, UpdateMembershipSubscriptionInformationDTO updateMembershipSubscriptionInformation)
        {
            var specifiedMembershipSubscription = await _dbContext.MembershipSubscriptions
                                                  .FirstOrDefaultAsync(m => m.ID == membershipSubscriptionId);
            if (specifiedMembershipSubscription is null)
                throw new ValidationException("This membership subscription isn't exist");

            specifiedMembershipSubscription.StartDate = updateMembershipSubscriptionInformation.StartDate;
            specifiedMembershipSubscription.EndDate = updateMembershipSubscriptionInformation.EndDate;
            specifiedMembershipSubscription.Status = updateMembershipSubscriptionInformation.Status;
            specifiedMembershipSubscription.isActive = updateMembershipSubscriptionInformation.isActive;
            specifiedMembershipSubscription.MemberID = updateMembershipSubscriptionInformation.MemberID;
            specifiedMembershipSubscription.MembershipPlanID = updateMembershipSubscriptionInformation.MembershipPlanID;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MembershipSubscription, MembershipSubscriptionToReturnDTO>(specifiedMembershipSubscription);
        }
    }
}

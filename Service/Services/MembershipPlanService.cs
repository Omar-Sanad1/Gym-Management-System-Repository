using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.Interfaces;
using Service.Models.MembershipPlansModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MembershipPlanService : IMembershipPlanService
    {
        private readonly GymManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public MembershipPlanService(GymManagementSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MembershipPlanToReturnDTO>> GetAllMembershipPlansAsync()
        {
            var membershipPlans = await _dbContext.MembershipPlans.ToListAsync();

            return _mapper.Map<IEnumerable<MembershipPlan>, IEnumerable<MembershipPlanToReturnDTO>>(membershipPlans);
        }

        public IEnumerable<MembershipPlanToReturnDTO> GetAllMembershipPlansFiltered(Func<MembershipPlan, bool> Filter)
        {
            var membershipPlansFiltered = _dbContext.Set<MembershipPlan>()
                                          .Where(Filter)
                                          .ToList();

            return _mapper.Map<IEnumerable<MembershipPlan>, IEnumerable<MembershipPlanToReturnDTO>>(membershipPlansFiltered);
        }

        public async Task<IEnumerable<MembershipPlanToReturnDTO>> GetAllMembershipPlansPagedAsync(int pageNumber, int pageSize)
        {
            var membershipPlansPaged = await _dbContext.Set<MembershipPlan>()
                                       .Skip((pageNumber - 1) * pageSize)
                                       .Take(pageSize)
                                       .ToListAsync();

            return _mapper.Map<IEnumerable<MembershipPlan>, IEnumerable<MembershipPlanToReturnDTO>>(membershipPlansPaged);
        }

        public int GetMembershipPlansCount()
        {
            return _dbContext.Set<MembershipPlan>()
                   .Count();
        }

        public async Task<MembershipPlanToReturnDTO> GetMembershipPlanByIDAsync(int membershipPlanId)
        {
            var specifiedMembershipPlan = await _dbContext.MembershipPlans.FirstOrDefaultAsync(m=>m.ID == membershipPlanId);
            if (specifiedMembershipPlan is null)
                throw new ValidationException("This membership plan isn't exist");

            return _mapper.Map<MembershipPlan, MembershipPlanToReturnDTO>(specifiedMembershipPlan);
        }
        public async Task<MembershipPlanToReturnDTO> CreateNewMembershipPlanAsync(CreateMembershipPlanDTO createMembershipPlan)
        {
            var membershipPlan = new MembershipPlan
            {
                PlanName = createMembershipPlan.PlanName,
                Duration = createMembershipPlan.Duration,
                Fee = createMembershipPlan.Fee,
                Benefits = createMembershipPlan.Benefits,
                AccessLevel = createMembershipPlan.AccessLevel
            };

            await _dbContext.MembershipPlans.AddAsync(membershipPlan);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MembershipPlan, MembershipPlanToReturnDTO>(membershipPlan);
        }

        public async Task DeleteMembershipPlanByIDAsync(int membershipPlanId)
        {
            var specifiedMembershipPlan = await _dbContext.MembershipPlans.FindAsync(membershipPlanId);
            if (specifiedMembershipPlan is null)
                throw new ValidationException("This membership plan isn't exist");

            _dbContext.MembershipPlans.Remove(specifiedMembershipPlan);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<MembershipPlanToReturnDTO> UpdateMembershipPlanInformationAsync(int membershipPlanId, UpdateMembershipPlanInformation updateMembershipPlan)
        {
            var specifiedMembershipPlan = await _dbContext.MembershipPlans.FindAsync(membershipPlanId);
            if (specifiedMembershipPlan is null)
                throw new ValidationException("This membership plan isn't exist");

            specifiedMembershipPlan.PlanName = updateMembershipPlan.PlanName;
            specifiedMembershipPlan.Duration = updateMembershipPlan.Duration;
            specifiedMembershipPlan.Fee = updateMembershipPlan.Fee;
            specifiedMembershipPlan.Benefits = updateMembershipPlan.Benefits;
            specifiedMembershipPlan.AccessLevel = updateMembershipPlan.AccessLevel;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<MembershipPlan, MembershipPlanToReturnDTO>(specifiedMembershipPlan);
        }
    }
}

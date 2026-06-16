using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.Interfaces;
using Service.Models.MembersModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class MemberService : IMemberService
    {
        private readonly GymManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public MemberService(GymManagementSystemDbContext dbContext,IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MemberToReturnDTO>> GetAllMembersAsync()
        {
            var members = await _dbContext.Members.ToListAsync();

            return _mapper.Map<IEnumerable<Member>, IEnumerable<MemberToReturnDTO>>(members);
        }


        public IEnumerable<MemberToReturnDTO> GetAllMembersFiltered(Func<Member, bool> Filter)
        {
            var membersFiltered =  _dbContext.Set<Member>()
                                   .Where(Filter)
                                   .ToList();

            return _mapper.Map<IEnumerable<Member>, IEnumerable<MemberToReturnDTO>>(membersFiltered);
        }


        public async Task<IEnumerable<MemberToReturnDTO>> GetAllMembersPagedAsync(int pageNumber, int pageSize)
        {
            var membersPaged = await _dbContext.Set<Member>()
                               .Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            return _mapper.Map<IEnumerable<Member>, IEnumerable<MemberToReturnDTO>>(membersPaged);
        }
        public async Task<MemberToReturnDTO> GetMemberByIDAsync(int memberId)
        {
            var specifiedMember = await _dbContext.Members.FirstOrDefaultAsync(m=>m.ID == memberId);
            if (specifiedMember is null)
                throw new ValidationException("This member isn't exist.");

            return _mapper.Map<Member,MemberToReturnDTO>(specifiedMember);
        }

        public int GetMembersCount()
        {
            return _dbContext.Members.Count();
        }

        public async Task DeleteMemberAsync(int memberId)
        {
            var specifiedMember = await _dbContext.Members.FindAsync(memberId);
            if (specifiedMember is null)
                throw new ValidationException("This member isn't exist.");

            _dbContext.Members.Remove(specifiedMember);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<MemberToReturnDTO> UpdateMemberInformationAsync(int memberId, UpdateMemberInformationDTO updateMemberInformation)
        {
            var specifiedMember = await _dbContext.Members.FindAsync(memberId);
            if (specifiedMember is null)
                throw new ValidationException("This member isn't exist.");

            var validStatuses = new[] { "Active" , "Inactive"};
            if (!validStatuses.Contains(updateMemberInformation.AccountStatus))
                throw new ValidationException("This status isn't valid.Valid statuses(Active , Inactive)");

            specifiedMember.FullName = updateMemberInformation.FullName;
            specifiedMember.PhoneNumber = updateMemberInformation.PhoneNumber;
            specifiedMember.EmailAddress = updateMemberInformation.EmailAddress;
            specifiedMember.DateOfBirth = updateMemberInformation.DateOfBirth;
            specifiedMember.AccountStatus = updateMemberInformation.AccountStatus;
            specifiedMember.EmergencyContactInformation = updateMemberInformation.EmergencyContactInformation;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Member, MemberToReturnDTO>(specifiedMember);

        }
    }
}

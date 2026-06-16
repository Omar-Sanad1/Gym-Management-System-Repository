using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using GymManagementSystem.Helper;
using GymManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Repository.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GymManagementSystem.Services
{
    public class AuthService : IAuthService
    {
        private readonly IGenericRepository<Member> _repo;
        private readonly JWT _jwt;
        public AuthService(IGenericRepository<Member> repo, IOptions<JWT> jwt)
        {
            _repo = repo;
            _jwt = jwt.Value;
        }
        public async Task<MemberToReturnDTO> RegisterMemberAsync(RegisterMemberModel registerMember)
        {
            var existsEmail = _repo.GetAll().FirstOrDefault(m=>m.EmailAddress == registerMember.EmailAddress);
            if (existsEmail is not null)
                throw new ValidationException("This email registered before.");

            var hashedPassword = BCrypt.Net.BCrypt.HashPassword(registerMember.Password);

            var member = new Member
            {
                FullName = registerMember.FullName,
                EmailAddress = registerMember.EmailAddress,
                PaswordHash = hashedPassword,
                PhoneNumber = registerMember.PhoneNumber,
                Gender = registerMember.Gender,
                DateOfBirth = registerMember.DateOfBirth,
                EmergencyContactInformation = registerMember.EmergencyContactInformation,
                AccountStatus = "Active",
                BranchID = registerMember.BranchID,
                TrainerID = registerMember.TrainerID
            };

            _repo.Add(member);

            return new MemberToReturnDTO
            {
                FullName = member.FullName,
                PhoneNumber = member.PhoneNumber,
                EmailAddress = member.EmailAddress,
                AccountStatus = "Active",
                RegisterationDate = DateTime.Now,
                DateOfBirth = member.DateOfBirth,
                Gender = member.Gender,
                BranchID = member.BranchID,
                Token = await CreateTokenAsync(member)
            };

        }
        public async Task<MemberToReturnDTO> LoginMemberAsync(LoginMemberModel loginMember)
        {
            var existsEmail = _repo.GetAll().FirstOrDefault(m => m.EmailAddress == loginMember.EmailAddress);
            if (existsEmail is null)
                throw new ValidationException("Email or password is incorrect.");

            var verifyPassword = BCrypt.Net.BCrypt.Verify(loginMember.Password,existsEmail.PaswordHash);

            if (!verifyPassword)
                throw new ValidationException("Email or password is incorrect.");

            return new MemberToReturnDTO
            {
                FullName = existsEmail.FullName,
                PhoneNumber = existsEmail.PhoneNumber,
                EmailAddress = existsEmail.EmailAddress,
                AccountStatus = existsEmail.AccountStatus,
                DateOfBirth = existsEmail.DateOfBirth,
                Gender = existsEmail.Gender,
                EmergencyContactInformation = existsEmail.EmergencyContactInformation,
                BranchID = existsEmail.BranchID,
                Token = await CreateTokenAsync(existsEmail)
            };
        }

        public async Task<string> CreateTokenAsync(Member member)
        {
            var claims = new []
            {
                new Claim(JwtRegisteredClaimNames.Sub , member.FullName),
                new Claim(JwtRegisteredClaimNames.Email , member.EmailAddress),
                new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString())
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwt.Key));

            var singningCrediantls = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken
                (
                    issuer:_jwt.Issuer,
                    audience:_jwt.Audience,
                    expires:DateTime.Now.AddDays(_jwt.DurationInDays),
                    claims:claims,
                    signingCredentials:singningCrediantls
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
        }
        

    }
}

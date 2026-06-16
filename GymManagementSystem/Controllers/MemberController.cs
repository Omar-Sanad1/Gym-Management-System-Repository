using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models.MembersModels;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpGet("GetAllMembersPagedFiltered")]
        public async Task<IActionResult> GetAllMembersPagedFiltered([FromQuery] MemberFiltering memberFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            // 1. جبت كل الMembers
            var members =  _memberService.GetAllMembersFiltered(m =>
            // فلترة بالاسم
            (string.IsNullOrEmpty(memberFiltering.FullName) || ((Member)(object)m).FullName == memberFiltering.FullName)&&
            // فلترة ب EmailAddress
            (string.IsNullOrEmpty(memberFiltering.EmailAddress) || ((Member)(object)m).EmailAddress == memberFiltering.EmailAddress)&&
            // فلترة ب PhoneNumber
            (string.IsNullOrEmpty(memberFiltering.PhoneNumber) || ((Member)(object)m).PhoneNumber == memberFiltering.PhoneNumber) &&
            // فلترة ب BranchID
            (!memberFiltering.BranchID.HasValue || ((Member)(object)m).BranchID == memberFiltering.BranchID)&&
            // فلترة ب TrainerID
            (!memberFiltering.TrainerID.HasValue || ((Member)(object)m).TrainerID == memberFiltering.TrainerID)
            );

            // 2. Pagination
            var totalMembers = _memberService.GetMembersCount();
            var pagedMembers = await _memberService.GetAllMembersPagedAsync(paginationParameters.PageNumber, paginationParameters.PageSize);

            var result = new PaginationResponse<MemberToReturnDTO>
                (
                    data:members,
                    totalItems:totalMembers,
                    pageNumber:paginationParameters.PageNumber,
                    pageSize:paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("GetMemberByID")]
        public async Task<IActionResult> GetMemberByIDAsync(int id)
        {
            var member = await _memberService.GetMemberByIDAsync(id);
            return Ok(member);
        }


        [HttpPut("UpdateMemberInformation")]
        public async Task<IActionResult> UpdateMemberInformationAsync(int memberId,UpdateMemberInformationDTO updateMemberInformation)
        {
            var updatedMember = await _memberService.UpdateMemberInformationAsync(memberId, updateMemberInformation);
            return Ok(updatedMember);
        }

        [HttpDelete("DeleteMemberAsync")]
        public async Task DeleteMemberAsync(int memberID)
        {
            await _memberService.DeleteMemberAsync(memberID);
        }
    }
}

using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models.MembershipPlansModels;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipPlanController : ControllerBase
    {
        private readonly IMembershipPlanService _membershipPlanService;
        public MembershipPlanController(IMembershipPlanService membershipPlanService)
        {
            _membershipPlanService = membershipPlanService;
        }

        [HttpGet("GetAllPagedFiltered")]
        public async Task<IActionResult> GetAllPagedFilteredAsync([FromQuery] MembershipPlanFiltering membershipPlanFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            var membershipPlans = _membershipPlanService.GetAllMembershipPlansFiltered(m =>
            // فلترة ب PlanName
            (string.IsNullOrEmpty(membershipPlanFiltering.PlanName) || ((MembershipPlan)(object)(m)).PlanName == membershipPlanFiltering.PlanName)&&
            // فلترة ب Duration
            (!membershipPlanFiltering.Duration.HasValue || ((MembershipPlan)(object)m).Duration == membershipPlanFiltering.Duration)&&
            // فلترة ب Fee
            (!membershipPlanFiltering.Fee.HasValue || ((MembershipPlan)(object)m).Fee == membershipPlanFiltering.Fee)&&
            // فلترة ب Benefits
            (string.IsNullOrEmpty(membershipPlanFiltering.Benefits) || ((MembershipPlan)(object)m).Benefits == membershipPlanFiltering.Benefits)
            );

            var totalmembershipPlans = _membershipPlanService.GetMembershipPlansCount();
            var membershipPlansPaged = await _membershipPlanService.GetAllMembershipPlansPagedAsync(paginationParameters.PageNumber, paginationParameters.PageSize);


            var result = new PaginationResponse<MembershipPlanToReturnDTO>
                (
                    data: membershipPlans,
                    totalItems: totalmembershipPlans,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("GetMembershipPlanByID")]
        public async Task<IActionResult> GetMembershipPlanByIDAsync(int id)
        {
            var membershipPlan = await _membershipPlanService.GetMembershipPlanByIDAsync(id);
            return Ok(membershipPlan);
        }

        [HttpPost("CreateNewMembershipPlan")]
        public async Task<IActionResult> CreateNewMembershipPlanAsync(CreateMembershipPlanDTO createMembershipPlan)
        {
            var createdMembershipPlan = await _membershipPlanService.CreateNewMembershipPlanAsync(createMembershipPlan);
            return Ok(createdMembershipPlan);
        }

        [HttpPut("UpdateMembershipPlanInformation")]
        public async Task<IActionResult> UpdateMembershipPlanInformation(int membershipPlanId, UpdateMembershipPlanInformation updateMembershipPlan)
        {
            var createdMembershipPlan = await _membershipPlanService.UpdateMembershipPlanInformationAsync(membershipPlanId , updateMembershipPlan);
            return Ok(createdMembershipPlan);
        }

        [HttpDelete("DeleteMembershipPlanByID")]
        public async Task DeleteMembershipPlanByIDAsync(int membershipPlanId)
        {
            await _membershipPlanService.DeleteMembershipPlanByIDAsync(membershipPlanId);
        }
    }
}

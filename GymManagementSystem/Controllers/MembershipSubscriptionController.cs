using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models.MembershipSubscriptionsModels;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MembershipSubscriptionController : ControllerBase
    {
        private readonly IMembershipSubscriptionService _membershipSubscriptionService;
        public MembershipSubscriptionController(IMembershipSubscriptionService membershipSubscriptionService)
        {
           _membershipSubscriptionService = membershipSubscriptionService;
        }

        [HttpGet("GetAllMembershipSubscriptionsPagedFiltered")]
        public async Task<IActionResult> GetAllMembershipSubscriptionsPagedFilteredAsync([FromQuery] MembershipSubscriptionFiltering membershipSubscriptionFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            // Filtering

            var membershipSubscriptions = _membershipSubscriptionService.GetAllMembershipSubscriptionsFiltered(m =>
            // فلترة ب MemberID
            (!membershipSubscriptionFiltering.MemberID.HasValue || ((MembershipSubscription)(object)m).MemberID == membershipSubscriptionFiltering.MemberID)&&
            // فلترة ب MembershipPlanID
            (!membershipSubscriptionFiltering.MembershipPlanID.HasValue || ((MembershipSubscription)(object)m).MembershipPlanID == membershipSubscriptionFiltering.MembershipPlanID) &&
            // فلترة ب Status
            (string.IsNullOrEmpty(membershipSubscriptionFiltering.Status) || ((MembershipSubscription)(object)m).Status == membershipSubscriptionFiltering.Status)
            );

            // Sorting

            membershipSubscriptions = membershipSubscriptionFiltering.SortBy?.ToLower() switch
            {
                "startdate" => membershipSubscriptionFiltering.isDescending
                ? membershipSubscriptions.OrderByDescending(m=>m.StartDate)
                : membershipSubscriptions.OrderBy(m=>m.StartDate),

                "enddate" => membershipSubscriptionFiltering.isDescending
                ? membershipSubscriptions.OrderByDescending(m=>m.EndDate)
                : membershipSubscriptions.OrderBy(m=>m.EndDate),

                _ => membershipSubscriptions.OrderBy(m=>m.ID)
            };


            // Pagination

            var totalmembershipSubscriptions = _membershipSubscriptionService.GetMembershipSubscriptionsCount();
            var membershipSubscriptionsPaged = _membershipSubscriptionService.GetAllMembershipSubscriptionsPagedAsync(paginationParameters.PageNumber, paginationParameters.PageSize);

            var result = new PaginationResponse<MembershipSubscriptionToReturnDTO>
                (
                    data: membershipSubscriptions ,
                    totalItems: totalmembershipSubscriptions,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("GetMembershipSubscriptionByID")]
        public async Task<IActionResult> GetMembershipSubscriptionByIDAsync(int id)
        {
            var membershipSubscription = _membershipSubscriptionService.GetMembershipSubscriptionByIDAsync(id);
            return Ok(membershipSubscription);
        }


        [HttpPost("CreateNewMembershipSubscription")]
        public async Task<IActionResult> CreateNewMembershipSubscriptionAsync(CreateMembershipSubscriptionDTO createMembershipSubscription)
        {
            var createdMembershipSubscription = await _membershipSubscriptionService.CreateNewMembershipSubscriptionAsync(createMembershipSubscription);
            return Ok(createdMembershipSubscription);
        }

        [HttpPut("UpdateMembershipSubscriptionInformation")]
        public async Task<IActionResult> UpdateMembershipSubscriptionInformationAsync(int membershipSubscriptionId, UpdateMembershipSubscriptionInformationDTO updateMembershipSubscriptionInformation)
        {
            var updatedMembershipSubscription = await _membershipSubscriptionService.UpdateMembershipSubscriptionInformationAsync(membershipSubscriptionId, updateMembershipSubscriptionInformation);
            return Ok(updatedMembershipSubscription);
        }

        [HttpDelete("DeleteMembershipSubscriptionByID")]
        public async Task DeleteMembershipSubscriptionByIDAsync(int membershipSubscriptionId)
        {
            await _membershipSubscriptionService.DeleteMembershipSubscriptionByIDAsync(membershipSubscriptionId);
        }
    }
}

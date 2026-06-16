using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Filtering;
using Core.Interfaces;
using Core.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Interfaces;
using Service.Models.PaymentsModels;

namespace GymManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        public PaymentController(IPaymentService paymentService)
        {
           _paymentService = paymentService;
        }

        [HttpGet("GetAllPaymentsPagedFiltered")]
        public Task<IActionResult> GetAllPaymentsPagedFilteredAsync([FromQuery] PaymentFiltering paymentFiltering,[FromQuery] PaginationParameters paginationParameters)
        {
            var payments = _paymentService.GetAllPaymentsFiltered(p =>
            // فلترة ب TransactionReferenceNumber
            (string.IsNullOrEmpty(paymentFiltering.TransactionReferenceNumber) || ((Payment)(object)(p)).TransactionReferenceNumber == paymentFiltering.TransactionReferenceNumber)&&
            // فلترة ب PaymentDate
            (!paymentFiltering.PaymentDate.HasValue || ((Payment)(object)p).PaymentDate == paymentFiltering.PaymentDate)
            );

            var totalpayments = _paymentService.GetPaymetsCount();
            var paymentsPaged = _paymentService.GetAllPaymentsPagedAsync(paginationParameters.PageNumber, paginationParameters.PageSize);

            var result = new PaginationResponse<PaymentToReturnDTO>
                (
                    data: payments,
                    totalItems: totalpayments,
                    pageNumber: paginationParameters.PageNumber,
                    pageSize: paginationParameters.PageSize
                );

            return Ok(result);
        }

        [HttpGet("GetPaymentByID")]
        public IActionResult GetPaymentByIDAsync(int id)
        {
            var payment = _paymentService.GetPaymentByIDAsync(id);
            return Ok(payment);
        }

        
        [HttpPut("UpdatePaymentInformationAsync")]
        public async Task<IActionResult> UpdatePaymentInformationAsync(int paymentId, UpdatePaymentInformationDTO updatePaymentInformation)
        {
            var updatedPayment = await _paymentService.UpdatePaymentInformationAsync(paymentId, updatePaymentInformation);
            return Ok(updatedPayment);
        }

        [HttpDelete("DeletePaymentByID")]
        public async Task DeletePaymentByIDAsync(int paymentId)
        {
            await _paymentService.DeletePaymentByIDAsync(paymentId);
        }
    }
}

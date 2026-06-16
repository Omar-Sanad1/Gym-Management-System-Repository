using Core.DTOs;
using Core.Entities;
using Service.Models.MembersModels;
using Service.Models.PaymentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    public interface IPaymentService
    {
        public Task<IEnumerable<PaymentToReturnDTO>> GetAllPaymentsAsync();
        public Task<IEnumerable<PaymentToReturnDTO>> GetAllPaymentsPagedAsync(int pageNumber, int pageSize);
        public int GetPaymetsCount();

        public IEnumerable<PaymentToReturnDTO> GetAllPaymentsFiltered(Func<Payment, bool> Filter);
        public Task<PaymentToReturnDTO> GetPaymentByIDAsync(int paymentId);
        public Task<PaymentToReturnDTO> UpdatePaymentInformationAsync(int paymentId, UpdatePaymentInformationDTO updatePaymentInformation);
        public Task DeletePaymentByIDAsync(int paymentId);
    }
}

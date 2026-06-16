using AutoMapper;
using Core.DTOs;
using Core.Entities;
using Core.Exceptions;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Service.Interfaces;
using Service.Models.MembersModels;
using Service.Models.PaymentsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class PaymentService : IPaymentService
    {
        private readonly GymManagementSystemDbContext _dbContext;
        private readonly IMapper _mapper;
        public PaymentService(GymManagementSystemDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<PaymentToReturnDTO>> GetAllPaymentsAsync()
        {
            var payments = await _dbContext.Payments.ToListAsync();

            return _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentToReturnDTO>>(payments);
        }


        public IEnumerable<PaymentToReturnDTO> GetAllPaymentsFiltered(Func<Payment, bool> Filter)
        {
            var paymentsFiltered = _dbContext.Set<Payment>()
                                   .Where(Filter)
                                   .ToList();

            return _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentToReturnDTO>>(paymentsFiltered);
        }


        public async Task<IEnumerable<PaymentToReturnDTO>> GetAllPaymentsPagedAsync(int pageNumber, int pageSize)
        {
            var paymentsPaged = await _dbContext.Set<Payment>()
                               .Skip((pageNumber - 1) * pageSize)
                               .Take(pageSize)
                               .ToListAsync();

            return _mapper.Map<IEnumerable<Payment>, IEnumerable<PaymentToReturnDTO>>(paymentsPaged);
        }
        public async Task<PaymentToReturnDTO> GetPaymentByIDAsync(int paymentId)
        {
            var specifiedPayment = await _dbContext.Payments.FirstOrDefaultAsync(p => p.ID == paymentId);
            if (specifiedPayment is null)
                throw new ValidationException("This payment isn't exist.");

            return _mapper.Map<Payment, PaymentToReturnDTO>(specifiedPayment);
        }

        public int GetPaymetsCount()
        {
            return _dbContext.Payments.Count();
        }

        public async Task DeletePaymentByIDAsync(int paymentId)
        {
            var specifiedPayment = await _dbContext.Payments.FindAsync(paymentId);
            if (specifiedPayment is null)
                throw new ValidationException("This payment isn't exist.");

            _dbContext.Payments.Remove(specifiedPayment);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<PaymentToReturnDTO> UpdatePaymentInformationAsync(int paymentId, UpdatePaymentInformationDTO updatePaymentInformation)
        {
            var specifiedPayment = await _dbContext.Payments.FindAsync(paymentId);
            if (specifiedPayment is null)
                throw new ValidationException("This payment isn't exist.");

            var validStatuses = new[] { "Paid", "Pending", "NotPaid" };
            if (!validStatuses.Contains(updatePaymentInformation.PaymentStatus))
                throw new ValidationException("This status isn't valid.Valid statuses(Paid , Pending , NotPaid)");

            specifiedPayment.PaymentMethod = updatePaymentInformation.PaymentMethod;
            specifiedPayment.PaymentDate = updatePaymentInformation.PaymentDate;
            specifiedPayment.PaymentStatus = updatePaymentInformation.PaymentStatus;
            specifiedPayment.PaymentAmount = updatePaymentInformation.PaymentAmount;
            specifiedPayment.TransactionReferenceNumber = updatePaymentInformation.TransactionReferenceNumber;
            specifiedPayment.RelatedMembershipSubscription = updatePaymentInformation.RelatedMembershipSubscription;
            specifiedPayment.MembershipSubscriptionID = updatePaymentInformation.MembershipSubscriptionID;

            await _dbContext.SaveChangesAsync();

            return _mapper.Map<Payment, PaymentToReturnDTO>(specifiedPayment);

        }
    }
}
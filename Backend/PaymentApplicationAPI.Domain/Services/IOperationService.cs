using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Infrastructure.Entities;

namespace PaymentApplicationAPI.Domain.Services
{
    public interface IOperationService
    {
        Task<PaymentResultModel> CreatePayment(PaymentModel payment);

        Task<List<MoneyReason>> GetMoneyReasons();

        Task<List<PaymentStatus>> GetPaymentStatus();

        Task<List<PaymentType>> GetPaymentTypes();

        Task<List<PaymentModelResponse>> GetPayments();

    }
}

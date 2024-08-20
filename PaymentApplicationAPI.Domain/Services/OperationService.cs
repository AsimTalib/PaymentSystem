using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Infrastructure.DataAccessLayer;
using PaymentApplicationAPI.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Services
{
    public class OperationService :IOperationService    
    {
        private PaymentCollectionDBContext _dbContext;
        private ILogger<OperationService> _logger;   
        public OperationService(PaymentCollectionDBContext dbContext, ILogger<OperationService> logger)
        { 
            _dbContext = dbContext;
            _logger = logger;

            
        }

        public async Task<PaymentResultModel> CreatePayment(PaymentModel payment)
        {

            var result = new PaymentResultModel();

            _logger.LogInformation("Start payment service");

            try
            {
                var moneyReason = await _dbContext.MoneyReasons.FirstOrDefaultAsync(x => x.Id == payment.MoneyReasonId);
                var paymentType = await _dbContext.PaymentTypes.FirstOrDefaultAsync(x => x.Id == payment.PaymentTypeId);
                var paymentStatus = await _dbContext.PaymentStatuses.FirstOrDefaultAsync(x => x.Name.ToLower() == "In Progress");
                //populate tables 

                if(moneyReason == null)
                {
                    _logger.LogInformation("Money Reason table is empty");
                    await PopulateMoneyReason();
                    moneyReason = await _dbContext.MoneyReasons.FirstOrDefaultAsync(x => x.Id == payment.MoneyReasonId);

                }

                if (paymentStatus == null)
                {
                    _logger.LogInformation("Payment Status table is empty");
                    await PopulatePaymentStatus();
                    paymentStatus = await _dbContext.PaymentStatuses.FirstOrDefaultAsync(x => x.Name.ToLower() == "In Progress".ToLower());

                }

                if (paymentType == null)
                {
                    _logger.LogInformation("payment type table is empty");
                    await PopulatePaymentType();
                    paymentType = await _dbContext.PaymentTypes.FirstOrDefaultAsync(x => x.Id == payment.PaymentTypeId);

                }
                var payeeDetail = new PayeeDetail
                {
                    FirstName = payment.FirstName,
                    LastName = payment.LastName,
                    Address = payment.Address,
                    PostCode = payment.PostCode,
                    PhoneNumber = payment.PhoneNumber,
                    Email = payment.PhoneNumber

                };

                _logger.LogInformation($"payment being processed,Money Reason:{moneyReason}, Payment Type: {paymentType}, Payment Status:{paymentStatus}");

                if ((moneyReason != null) && (paymentType != null) && (paymentStatus != null))
                {
                    var serviceOperation = new ServiceOperation
                    {
                        
                        ExtraDetails = payment.ExtraDetails,
                        MoneyReason = moneyReason,
                        PayeeDetail = payeeDetail,
                        PaymentType = paymentType,
                        PaymentAmount = payment.PaymentAmount,
                        ReferenceId = Guid.NewGuid(),
                        PaymentStatus = paymentStatus

                    };
                    _dbContext.Add(serviceOperation);
                    _logger.LogInformation($"payment before being saved: {serviceOperation}");
                    await _dbContext.SaveChangesAsync();
                    _logger.LogInformation($"payment after being saved: {serviceOperation.ReferenceId}");
                    result.Status = paymentStatus.Name;
                    result.Success = true;
                    result.Message = "This has been processed";
                    result.Reference = serviceOperation.ReferenceId.ToString();

                }
            }
            catch(Exception ex)
            {
                _logger.LogError("Error {ex}",ex);
            }
            
           
            return result;

        }
        private async Task PopulatePaymentStatus()
        {
            var paymentStatuses = new List<PaymentStatus>{
                new PaymentStatus { Name = "In Progress" },
                new PaymentStatus { Name = "Complete" },
                new PaymentStatus { Name = "Cancelled" }};

            _dbContext.AddRange(paymentStatuses);         
            await _dbContext.SaveChangesAsync();
        }
        private async Task PopulateMoneyReason()
        {
            var moneyReasons = new List<MoneyReason> {
                new MoneyReason { Name = "Charity"},
                new MoneyReason { Name = "Community Hall" },
                new MoneyReason { Name = "Membership" },
                new MoneyReason { Name = "Renovations" } };

            _dbContext.AddRange(moneyReasons);
            await _dbContext.SaveChangesAsync();
        }
        private async Task PopulatePaymentType()
        {
            var paymentTypes = new List<PaymentType> {new PaymentType { Name = "Cash" },
                new PaymentType { Name = "Card" } };
            _dbContext.AddRange(paymentTypes);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MoneyReason>> GetMoneyReasons()
        {
            var result = await _dbContext.MoneyReasons.ToListAsync();
            return result;
        }

        public async Task<List<PaymentStatus>> GetPaymentStatus()
        {
            var result = await _dbContext.PaymentStatuses.ToListAsync();
            return result;
        }

        public async Task<List<PaymentType>> GetPaymentTypes()
        {
            var result = await _dbContext.PaymentTypes.ToListAsync();
            return result;
        }

        public async Task<List<PaymentModelResponse>> GetPayments()
        {
            var result = await _dbContext.ServiceOperations.Include(x=>x.PayeeDetail).Include(x=>x.PaymentStatus).Include(x=>x.MoneyReason).ToListAsync();
            var converted = ConvertFromServiceOperationToPaymentModel(result);
            return converted;
        }

        private List<PaymentModelResponse> ConvertFromServiceOperationToPaymentModel(List<ServiceOperation> serviceOperation)
        {
            var result = serviceOperation.Select(x => new PaymentModelResponse
            {
                FirstName = x.PayeeDetail.FirstName,
                LastName = x.PayeeDetail.LastName,
                Address = x.PayeeDetail.Address,
                Email = x.PayeeDetail.Email,
                PhoneNumber = x.PayeeDetail.PhoneNumber,
                PostCode = x.PayeeDetail.PostCode,
                ExtraDetails = x.ExtraDetails,
                MoneyReasonId = x.MoneyReason.Id,
                MoneyReason = x.MoneyReason.Name,
                PaymentAmount = x.PaymentAmount,
                PaymentTypeId = x.PaymentTypeId,
                PaymentStatus = x.PaymentStatus.Name,
                PaymentStatusId = x.PaymentStatus.Id,
                ReferenceNumber = x.ReferenceId

            }).ToList();
            return result;
        }
    }
}

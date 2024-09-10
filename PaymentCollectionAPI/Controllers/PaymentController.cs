using Microsoft.AspNetCore.Mvc;
using PaymentApplicationAPI.API.Models;
using PaymentApplicationAPI.Domain.Models;
using PaymentApplicationAPI.Domain.Services;

namespace PaymentApplicationAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class PaymentController : ControllerBase
    {
        private IOperationService _operationService;
       
        public PaymentController(IOperationService operationService)
        {
            _operationService = operationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostUserPayment([FromBody] PaymentDetails paymentDetails)
        {
            var paymentModelModel = new PaymentModel
            {
                FirstName = paymentDetails.FirstName,
                LastName = paymentDetails.LastName,
                Address = paymentDetails.Address,
                PostCode = paymentDetails.PostCode,
                PhoneNumber = paymentDetails.PhoneNumber,
                Email = paymentDetails.Email,
                PaymentTypeId = paymentDetails.PaymentType,
                MoneyReasonId = paymentDetails.MoneyReason,
                PaymentAmount = paymentDetails.PaymentAmount,
                ExtraDetails = paymentDetails.ExtraDetails
            
            };

            var payment = await _operationService.CreatePayment(paymentModelModel);
            
            return Ok(payment);
        }
       

        [HttpGet("getmoneyreasons")]
        public async Task<IActionResult> GetMoneyReasons()
        {
            var result = await _operationService.GetMoneyReasons();
            return Ok(result);  
        }

        [HttpGet("getpaymentstatus")]
        public async Task<IActionResult> GetPaymentStatuses()
        {
            var result = await _operationService.GetPaymentStatus();
            return Ok(result);
        }

        [HttpGet("getpaymenttypes")]
        public async Task<IActionResult> GetPaymentTypes()
        {
            var result = await _operationService.GetPaymentTypes();
            return Ok(result);
        }

        [HttpGet("getpayments")]
        public async Task<IActionResult> GetPayments()
        {
            var result = await _operationService.GetPayments();
            return Ok(result);
        }




    }

}

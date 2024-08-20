using Microsoft.AspNetCore.Mvc;
using PaymentApplicationAPI.Domain.Services;

namespace PaymentSystem.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PaymentController : ControllerBase
    {
        private IOperationService _paymentService;
        public PaymentController(IOperationService paymentService ) 
        {
            _paymentService = paymentService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllPayments()
        {
            var query = await _paymentService.GetPayments();
            
            return Ok(query);
        } 
    }
}

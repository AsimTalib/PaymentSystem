using Microsoft.AspNetCore.Mvc;
using PaymentApplicationAPI.Domain.Services;
using PaymentSystem.Web.Server.model;

namespace PaymentSystem.Web.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private ILoginService _LoginService;
        public AccountController( ILoginService loginService) 
        {
            _LoginService = loginService;

        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody]LoginViewModel model)
        {
            var result = await _LoginService.CheckLogin(model.Username, model.Password);
            if (result)
            {
                return Ok();
            }
            return Forbid();
        }
    }
}

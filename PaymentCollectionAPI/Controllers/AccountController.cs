using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using PaymentApplicationAPI.API.Models;
using PaymentApplicationAPI.Domain.Services;

namespace PaymentApplicationAPI.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
       
       private ILoginService _loginService;
       public AccountController(ILoginService loginService) 
       {
            _loginService = loginService; 
       }

       [HttpPost]
       public async Task<IActionResult> GetUserToLogin([FromBody]UserLogin login) 
       {
            var UserLogin = await _loginService.CheckLogin(login.Username, login.Password);

            if (UserLogin)
            {
                return Ok();
            }
            else
            {
                return Unauthorized();
            } 
               
       }


    }
}

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using PaymentApplicationAPI.API.Controllers;
using PaymentApplicationAPI.API.Models;
using PaymentApplicationAPI.Domain.Services;
using PaymentApplicationAPI.Infrastructure.DataAccessLayer;
using PaymentApplicationAPI.Infrastructure.Entities;
using System.Text;

namespace PaymentApplicationAPI.Tests
{
    public class LoginUnitTest
    {
        private readonly ILoginService _LoginService;
        public LoginUnitTest()
        {
            //mock one table 
            //var MockSet = new Mock<DbSet<LoginAccount>>();
            var MockContext = new Mock<PaymentCollectionDBContext>();
            //MockContext.Setup(x => x.LoginAccounts).Returns(MockSet.Object);
            _LoginService = new LoginService(MockContext.Object);
        }

        [Fact]
        public async Task HashTest()
        {
            //ARRANGE
            var password = "admin";
            //ACT
            var result = _LoginService.GenerateHash(password);
            //ASSERT
            Assert.Equal(result, "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918");

        }

        [Fact]
        public async Task When_user_login_with_correct_password_return_ok()
        {

            //Task.async as mock doesnt have async

            //ARRANGE
            var loginService = new Mock<ILoginService>();
            string userName = "admin";
            string password = "admin";
            bool mockResult = true;

            //setup is for the sevice
            loginService.Setup(x => x.CheckLogin(userName, password)).ReturnsAsync(mockResult);

            var controller = new AccountController(loginService.Object);
           
            var payload = new UserLogin
            {
                 Username = userName,
                 Password = password
            };

            //ACT
            var result = (OkResult)await controller.GetUserToLogin(payload);
            
            //ASSERT
            Assert.Equal(StatusCodes.Status200OK,result.StatusCode);

        }

        [Fact]
        public async Task When_user_login_with_incorrect_password_return_unauthorised()
        {

            //Task.async as mock doesnt have async

            //ARRANGE
            var loginService = new Mock<ILoginService>();
            string userName = "admin";
            string password = "incorrect";
            bool mockResult = false;

            //setup is for the sevice
            loginService.Setup(x => x.CheckLogin(userName, password)).ReturnsAsync(mockResult);

            var controller = new AccountController(loginService.Object);

            var payload = new UserLogin
            {
                Username = userName,
                Password = password
            };

            //ACT
            var result = (UnauthorizedResult)await controller.GetUserToLogin(payload);

            //ASSERT
            Assert.Equal(StatusCodes.Status401Unauthorized, result.StatusCode);

        }
    }
}
using Microsoft.EntityFrameworkCore;
using PaymentApplicationAPI.Infrastructure.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Services
{
    public class LoginService : ILoginService
    {
        private PaymentCollectionDBContext _paymentDBContext;
        public LoginService(PaymentCollectionDBContext paymentDBContext) 
        { 
            _paymentDBContext = paymentDBContext;
        }

        ///check Login 
        public async Task<bool> CheckLogin(string username, string password)
        {
            var user = await _paymentDBContext.LoginAccounts.FirstOrDefaultAsync(x => x.Username == username); 
            if (user == null)
            {
                return false;
            } else
            {
                bool checkPassword = GenerateHash(password) == user.PasswordHash;
                return checkPassword;
            }
        }
        
        ///Hash Password
     
        public string GenerateHash( string pwd)
        {
            using (SHA256 hash = SHA256.Create()) {
                byte[] byteArray = hash.ComputeHash(Encoding.UTF8.GetBytes(pwd));
                StringBuilder builder = new StringBuilder();
                for (int i = 0 ; i < byteArray.Length; i++)
                {
                    builder.Append(byteArray[i].ToString("x2"));
                }
                return builder.ToString();
            }
            
        }
        
        
    }
}

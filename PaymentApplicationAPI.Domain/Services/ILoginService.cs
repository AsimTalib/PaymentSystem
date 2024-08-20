using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Services
{
    public interface ILoginService
    {
        Task<bool> CheckLogin(string username, string password);
        string GenerateHash(string pwd);




    }
}

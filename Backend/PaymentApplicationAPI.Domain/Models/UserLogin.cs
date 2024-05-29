using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Domain.Models
{
    public class UserLogin
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public bool IsLock { get; set; }
        public string UserAcess { get; set; }

    }
}

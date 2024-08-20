using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class LoginAccount : BaseEntity
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public int LoginFailed { get; set; }
        public bool IsLock { get; set; }
        public string UserAcess {  get; set; }

    }
}

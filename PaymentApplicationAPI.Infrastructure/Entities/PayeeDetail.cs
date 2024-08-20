using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class PayeeDetail : BaseUserDetails
    {
        //FK
        public virtual List<ServiceOperation> ServiceOperations { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class PaymentStatus : BaseEntity
    {
        public string Name { get; set; }

        public virtual List<ServiceOperation> Operations { get; set; }
    }
}

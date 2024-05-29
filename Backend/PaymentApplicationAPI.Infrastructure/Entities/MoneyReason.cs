using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class MoneyReason : BaseEntity
    {
        public string Name { get; set; }

        //connection back one to many
        public virtual List<ServiceOperation> ServiceOperations { get; set; }
    }
}

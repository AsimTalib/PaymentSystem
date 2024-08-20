using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class Membership : BaseUserDetails
    {
         
        //FK
        public int HouseId { get; set; }

        //access to that table from here - linked 
        public virtual House House { get; set; }
        public virtual List<ServiceOperation> ServiceOperations { get; set; }
    }
}

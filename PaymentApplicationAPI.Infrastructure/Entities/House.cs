using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class House :BaseEntity
    {
        public string DoorNumber {  get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Postcode { get; set; }
        public int Type { get; set; }
        //house has many members
        public virtual List<Membership> Memberships { get; set; }

    }
}

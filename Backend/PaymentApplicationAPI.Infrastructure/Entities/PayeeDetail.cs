﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class PayeeDetail : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public virtual List<ServiceOperation> ServiceOperations { get; set; }
    }
}

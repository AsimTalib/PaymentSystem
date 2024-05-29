using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public class ServiceOperation : BaseEntity
    {
        //Main Table

       public string? ExtraDetails { get; set; }

        public decimal PaymentAmount { get; set; }

        //FK
        public int MoneyReasonId {get; set; }
        public int PaymentTypeId { get; set; }
        public int PayeeDetailsId { get; set; }
        
        public int PaymentStatusId { get; set; }
        public Guid ReferenceId { get; set; }

        public virtual MoneyReason MoneyReason { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public virtual PayeeDetail PayeeDetail { get; set; }

        public virtual PaymentStatus PaymentStatus { get; set; }

    }
}

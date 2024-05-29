namespace PaymentApplicationAPI.Domain.Models
{
    public class PaymentModelResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int PaymentTypeId { get; set; }

        public int MoneyReasonId { get; set; }
        public string MoneyReason { get; set; }

        public decimal PaymentAmount { get; set; }

        public string? ExtraDetails { get; set; }

        public Guid ReferenceNumber { get; set; }
        public string PaymentStatus { get; set; }
        public int PaymentStatusId { get; set; }
        
    }
}
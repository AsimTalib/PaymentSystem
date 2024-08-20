namespace PaymentApplicationAPI.API.Models
{
    public class PaymentDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int PaymentType { get; set; }

        public int MoneyReason { get; set; }

        public decimal PaymentAmount { get; set; }

        public string ExtraDetails { get; set; }
    }
}
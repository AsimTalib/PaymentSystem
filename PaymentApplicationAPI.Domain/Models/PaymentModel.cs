namespace PaymentApplicationAPI.Domain.Models
{
    public class PaymentModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }

        public int PaymentTypeId { get; set; }

        public int MoneyReasonId { get; set; }

        public decimal PaymentAmount { get; set; }

        public string ExtraDetails { get; set; }


    }
}
namespace PaymentApplicationAPI.Domain.Models
{
    public class MemberModelResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Guid ReferenceNumber { get; set; }
        public int HouseId { get; set; }

    }
}
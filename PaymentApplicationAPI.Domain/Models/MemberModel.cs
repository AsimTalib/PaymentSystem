using PaymentApplicationAPI.Infrastructure.Entities;

namespace PaymentApplicationAPI.Domain.Models
{
    public class MemberModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string Number { get; set; }
        public string Address { get; set; }

        public string City { get; set; }
        public string PostCode { get; set; }
        public string PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int HouseType { get; set; }
        public int? HouseId { get; set; }

    }
}
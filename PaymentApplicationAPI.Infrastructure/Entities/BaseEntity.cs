namespace PaymentApplicationAPI.Infrastructure.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public string UpdateBy { get; set; } = "System";
        public string CreatedBy { get; set; } = "System";
        public DateTime UpdateAt { get; set; } = DateTime.UtcNow;
        public DateTime CreatedAt { get; set;} = DateTime.UtcNow;
    }
}

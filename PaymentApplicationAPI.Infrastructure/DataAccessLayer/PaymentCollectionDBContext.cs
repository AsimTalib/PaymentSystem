using Microsoft.EntityFrameworkCore;
using PaymentApplicationAPI.Infrastructure.Entities;

namespace PaymentApplicationAPI.Infrastructure.DataAccessLayer
{
    public class PaymentCollectionDBContext : DbContext
    {
        public DbSet<LoginAccount> LoginAccounts { get; set; }
        public DbSet<MoneyReason> MoneyReasons { get; set; }
        public DbSet<PayeeDetail> PayeeDetails { get; set; }
        public DbSet<PaymentType> PaymentTypes { get; set; }

        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
        public DbSet<ServiceOperation> ServiceOperations { get; set; }

        public DbSet<Membership> Memberships { get; set; }

        public DbSet<House> Houses { get; set; }

        //Empty constructor that initalises the DB context
        public PaymentCollectionDBContext()
        {

        }

        public PaymentCollectionDBContext(DbContextOptions<PaymentCollectionDBContext> options) :base(options)
        {
            
        }

    }
}

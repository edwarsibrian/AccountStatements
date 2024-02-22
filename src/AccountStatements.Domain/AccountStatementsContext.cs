using AccountStatements.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountStatements.Domain
{
    public class AccountStatementsContext : DbContext
    {
        public AccountStatementsContext(DbContextOptions options) : base(options)
        {
        }

        protected AccountStatementsContext()
        {
        }

        public DbSet<Holder> Holders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set;}
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AccountsStatements");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charge>()
                .HasOne(c => c.CreditCard)
                .WithMany(c => c.Charges)
                .HasForeignKey(c => c.Id);

            modelBuilder.Entity<CreditCard>()
                .HasOne(c=>c.Holder)
                .WithMany(c=>c.CreditCards)
                .HasForeignKey(c => c.Id);
        }
    }
}

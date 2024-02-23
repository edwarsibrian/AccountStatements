using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Utils;
using Microsoft.EntityFrameworkCore;

namespace AccountStatements.Repository
{
    public class AccountStatementsContext : DbContext
    {
        private readonly IEncryptDecryptString _encryptDecryptString;

        public AccountStatementsContext(DbContextOptions options, IEncryptDecryptString encryptDecryptString) : base(options)
        {
            _encryptDecryptString = encryptDecryptString;
        }

        protected AccountStatementsContext(IEncryptDecryptString encryptDecryptString)
        {
            _encryptDecryptString = encryptDecryptString;
        }

        public DbSet<Holder> Holders { get; set; }
        public DbSet<CreditCard> CreditCards { get; set;}
        public DbSet<Charge> Charges { get; set; }
        public DbSet<Setting> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AccountsStatements");
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=AccountsStatements");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charge>()
                .HasOne(c => c.CreditCard)
                .WithMany(c => c.Charges)
                .HasForeignKey(c => c.CreditCardId);

            modelBuilder.Entity<CreditCard>()
                .HasOne(c => c.Holder)
                .WithMany(c => c.CreditCards)
                .HasForeignKey(c => c.HolderId);


            //Seed Data
            modelBuilder.Entity<Holder>().HasData(
                new Holder
                {
                    Id = 1,
                    Name = "Edwar Morales"
                },
                new Holder
                {
                    Id = 2,
                    Name = "Juan Perez"
                });
            modelBuilder.Entity<CreditCard>().HasData(
                new CreditCard
                {
                    Id = 1,
                    HolderId = 1,
                    Number = _encryptDecryptString.EncryptString("1234854796328951"),
                    CreditLimit = 500,
                    AvailableBalance = 500
                },
                new CreditCard
                {
                    Id = 2,
                    HolderId = 2,
                    Number = _encryptDecryptString.EncryptString("2589445521459856"),
                    CreditLimit = 700,
                    AvailableBalance = 700
                });
        }
    }
}

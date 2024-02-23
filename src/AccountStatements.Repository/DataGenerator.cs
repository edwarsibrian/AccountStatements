using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace AccountStatements.Repository
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AccountStatementsContext(
                serviceProvider.GetRequiredService<DbContextOptions<AccountStatementsContext>>(),
                serviceProvider.GetRequiredService<IEncryptDecryptString>()))
            {
                //Look for any Holder
                if(context.Holders.Any())
                {
                    return;
                }

                context.Holders.AddRange(
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
                context.SaveChanges();

                //Look for any CreditCard
                if(context.CreditCards.Any())
                {
                    return;
                }

                var encryptDecryptString = new EncryptDecryptString(serviceProvider.GetRequiredService<IApplicationConfigManager>());

                context.CreditCards.AddRange(
                    new CreditCard
                    {
                        Id = 1,
                        HolderId = 1,
                        Number = encryptDecryptString.EncryptString("1234854796328951"),
                        CreditLimit = 500,
                        AvailableBalance = 500
                    },
                    new CreditCard
                    {
                        Id = 2,
                        HolderId = 2,
                        Number = encryptDecryptString.EncryptString("2589445521459856"),
                        CreditLimit = 700,
                        AvailableBalance = 700
                    });
                context.SaveChanges();
            }
        }
    }
}

using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using AccountStatements.Repository.Utils;
using Microsoft.EntityFrameworkCore;

namespace AccountStatements.Repository.Services
{
    public class CreditCardService : ICreditCardService
    {
        private readonly AccountStatementsContext _context;
        private readonly IEncryptDecryptString _encryptDecryptString;

        public CreditCardService(AccountStatementsContext context, IEncryptDecryptString encryptDecryptString)
        {
            _context = context;
            _encryptDecryptString = encryptDecryptString;
        }

        public async Task<List<CreditCard>> GetCreditCards()
        {
            var creditCards = await _context.CreditCards.Include("Holder").ToListAsync();

            creditCards.ForEach(cc => cc.Number = _encryptDecryptString.DecryptString(cc.Number));

            return creditCards;
        }

        public async Task<List<Holder>> GetHoldersWithCreditCards()
        {
            var holderAndCC = await _context.Holders.Include("CreditCards").ToListAsync();

            holderAndCC.ForEach(h =>
                h.CreditCards.ToList().ForEach(cc =>
                cc.Number = _encryptDecryptString.DecryptString(cc.Number)));

            return holderAndCC;
        }
    }
}

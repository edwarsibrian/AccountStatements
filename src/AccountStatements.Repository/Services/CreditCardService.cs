using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using AccountStatements.Repository.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var creditCards = await _context.CreditCards.ToListAsync();

            creditCards.ForEach(cc => cc.Number = _encryptDecryptString.DecryptString(cc.Number));

            return creditCards;
        }
    }
}

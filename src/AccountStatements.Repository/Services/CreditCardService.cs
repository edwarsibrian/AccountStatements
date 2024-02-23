using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
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

        public CreditCardService(AccountStatementsContext context)
        {
            _context = context;
        }

        public async Task<List<CreditCard>> GetCreditCards()
        {
            return await _context.CreditCards.ToListAsync();
        }
    }
}

using AccountStatements.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountStatements.Repository.Interfaces
{
    public interface ICreditCardService
    {
        Task<List<CreditCard>> GetCreditCards();
        Task<List<Holder>> GetHoldersWithCreditCards();
    }
}

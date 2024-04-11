using AccountStatements.Repository.Entities;

namespace AccountStatements.Interfaces
{
    public interface IAccountStatementsClient
    {
        Task<List<CreditCard>> GetAllCreditCards();
    }
}

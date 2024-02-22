using AccountStatements.Domain.Entities;

namespace AccountStatements.Domain.Repositories
{
    public interface ISettingRepository
    {
        Task<Setting> Get();
        Task<bool> Update(int id, decimal interestPct, decimal minBalancePct);
        Task<Setting> Create(Setting setting);
    }
}

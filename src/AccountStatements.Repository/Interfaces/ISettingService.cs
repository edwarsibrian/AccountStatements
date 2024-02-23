using AccountStatements.Repository.Entities;

namespace AccountStatements.Repository.Interfaces
{
    public interface ISettingService
    {
        Task<Setting> Get();
        Task<bool> Update(int id, decimal interestPct, decimal minBalancePct);
        Task<Setting> Create(Setting setting);
    }
}

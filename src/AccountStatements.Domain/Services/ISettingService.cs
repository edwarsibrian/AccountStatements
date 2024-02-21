using AccountStatements.Domain.Entities;

namespace AccountStatements.Domain.Services
{
    public interface ISettingService
    {
        Task<Setting> Get();
        Task<bool> Update(int id, decimal interestPct, decimal minBalancePct);
        Task<Setting> Create(Setting setting);
    }
}

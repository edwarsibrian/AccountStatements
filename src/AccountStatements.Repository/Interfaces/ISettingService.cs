using AccountStatements.Repository.Entities;

namespace AccountStatements.Repository.Interfaces
{
    public interface ISettingService
    {
        Task<Setting> Get();
        Task<bool> Update(Setting setting);
        Task<Setting> Create(Setting setting);
    }
}

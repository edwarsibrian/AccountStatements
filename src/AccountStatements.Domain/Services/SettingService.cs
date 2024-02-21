using AccountStatements.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace AccountStatements.Domain.Services
{
    public class SettingService : ISettingService
    {
        private AccountStatementsContext _context;

        public SettingService(AccountStatementsContext context)
        {
            _context = context;
        }

        public async Task<Setting> Create(Setting setting)
        {
            await _context.AddAsync(setting);
            int isSaved = await _context.SaveChangesAsync();

            return setting;
        }       

        public async Task<Setting> Get()
        {
            return await _context.Settings.FirstOrDefaultAsync();
        }

        public async Task<bool> Update(int id, decimal interestPct, decimal minBalancePct)
        {
            var setting = await _context.Settings.FirstOrDefaultAsync(s => s.Id == id);

            if (setting == null)
            {
                throw new Exception("Setting id invalid");
            }

            setting.InterestPct = interestPct;
            setting.MinBalancePct = minBalancePct;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}

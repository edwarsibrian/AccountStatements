using AccountStatements.Domain.Queries;
using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using MediatR;

namespace AccountStatements.Domain.Handlers
{
    public class GetSettingHandler : IRequestHandler<GetSettingQuery, Setting>
    {
        private readonly ISettingService _settingService;

        public GetSettingHandler(ISettingService settingService)
        {
            _settingService = settingService;
        }

        public async Task<Setting> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingService.Get();
        }
    }
}

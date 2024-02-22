using AccountStatements.API.Queries;
using AccountStatements.Domain.Entities;
using AccountStatements.Domain.Repositories;
using MediatR;

namespace AccountStatements.API.Handlers
{
    public class GetSettingHandler : IRequestHandler<GetSettingQuery, Setting>
    {
        private readonly ISettingRepository _settingRepository;

        public GetSettingHandler(ISettingRepository settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<Setting> Handle(GetSettingQuery request, CancellationToken cancellationToken)
        {
            return await _settingRepository.Get();
        }
    }
}

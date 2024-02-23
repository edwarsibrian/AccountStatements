using AccountStatements.Domain.Commands;
using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace AccountStatements.Domain.Handlers
{
    public class CreateSettingHandler : IRequestHandler<CreateSettingCommand, Setting>
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public CreateSettingHandler(ISettingService service, IMapper mapper)
        {
            _settingService = service;
            _mapper = mapper;
        }

        public async Task<Setting> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            return await _settingService.Create(_mapper.Map<Setting>(request));
        }
    }
}

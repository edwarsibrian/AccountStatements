using AccountStatements.Domain.Commands;
using AccountStatements.Repository.Entities;
using AccountStatements.Repository.Interfaces;
using AutoMapper;
using MediatR;

namespace AccountStatements.Domain.Handlers
{
    public class UpdateSettingHandler : IRequestHandler<UpdateSettingCommand, bool>
    {
        private readonly ISettingService _settingService;
        private readonly IMapper _mapper;

        public UpdateSettingHandler(ISettingService settingService, IMapper mapper)
        {
            _settingService = settingService;
            _mapper = mapper;
        }

        public async Task<bool> Handle(UpdateSettingCommand request, CancellationToken cancellationToken)
        {
            return await _settingService.Update(_mapper.Map<Setting>(request));
        }
    }
}

using AccountStatements.API.Commands;
using AccountStatements.Domain.Entities;
using AccountStatements.Domain.Repositories;
using AutoMapper;
using MediatR;

namespace AccountStatements.API.Handlers
{
    public class CreateSettingHandler : IRequestHandler<CreateSettingCommand, Setting>
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public CreateSettingHandler(ISettingRepository repository, IMapper mapper)
        {
            _settingRepository = repository;
            _mapper = mapper;
        }

        public async Task<Setting> Handle(CreateSettingCommand request, CancellationToken cancellationToken)
        {
            return await _settingRepository.Create(_mapper.Map<Setting>(request));
        }
    }
}

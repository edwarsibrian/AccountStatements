using AccountStatements.API.Commands;
using AccountStatements.API.Queries;
using AccountStatements.Domain.Entities;
using AutoMapper;

namespace AccountStatements.API.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateSettingCommand, Setting>();
        }
    }
}

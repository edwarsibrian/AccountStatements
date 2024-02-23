using AccountStatements.Domain.Commands;
using AccountStatements.Repository.Entities;
using AutoMapper;

namespace AccountStatements.Domain.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreateSettingCommand, Setting>();
            CreateMap<UpdateSettingCommand, Setting>();
        }
    }
}

using AccountStatements.Models;
using AccountStatements.Repository.Entities;
using AutoMapper;

namespace AccountStatements.Configurations
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<CreditCard, CreditCardsList>()
                .ForMember(ccl => ccl.Id, opt => opt.MapFrom(cc => cc.Id))
                .ForMember(ccl => ccl.Name, opt => opt.MapFrom(cc => cc.Holder.Name))
                .ForMember(ccl => ccl.FamilyName, opt => opt.MapFrom(cc => cc.Holder.FamilyName))
                .ForMember(ccl => ccl.CardNumber, opt => opt.MapFrom(cc => cc.Number));
        }
    }
}

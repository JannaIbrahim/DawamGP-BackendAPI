using AutoMapper;
using Dawam.API.DTOs;
using Dawam.DAL.Entities;

namespace Dawam.API.Helpers
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Waqf, WaqfToReturnDTO>()
                .ForMember(d => d.WaqfCountry, o => o.MapFrom(s => s.WaqfCountry.Name))
                .ForMember(d => d.WaqfCity, o => o.MapFrom(s => s.WaqfCity.Name))
                .ForMember(d => d.WaqfType, o => o.MapFrom(s => s.WaqfType.Name))
                .ForMember(d => d.WaqfActivity, o => o.MapFrom(s => s.WaqfActivity.Name))
                .ForMember(d => d.WaqfStatus, o => o.MapFrom(s => s.WaqfStatus.Name))
                .ForMember(d => d.InsUser, o => o.MapFrom(s => s.InsUser.Name))
                .ForMember(d => d.ConfirmUser, o => o.MapFrom(s => s.ConfirmUser.Name));

        }
    }
}

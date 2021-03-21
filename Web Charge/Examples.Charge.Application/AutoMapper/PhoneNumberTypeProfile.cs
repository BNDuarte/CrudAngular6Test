using AutoMapper;
using Examples.Charge.Application.Dtos;
using Examples.Charge.Domain.Aggregates.PersonAggregate;

namespace Examples.Charge.Application.AutoMapper
{
    class PhoneNumberTypeProfile : Profile
    {
        public PhoneNumberTypeProfile()
        {
            CreateMap<PhoneNumberType, PhoneNumberTypeDto>()
               .ReverseMap()
               .ForMember(dest => dest.PhoneNumberTypeID, opt => opt.MapFrom(src => src.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));

            CreateMap<PhoneNumberTypeDto, PhoneNumberType>()
              .ReverseMap()
              .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PhoneNumberTypeID))
              .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name));
        }
    }
}
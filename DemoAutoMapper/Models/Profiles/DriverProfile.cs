using AutoMapper;
using DemoAutoMapper.Models.DataModels;
using DemoAutoMapper.Models.IncomingModels;
using DemoAutoMapper.Models.OutgoingModels;
using Microsoft.AspNetCore.Routing.Constraints;

namespace DemoAutoMapper.Models.Profiles
{
    public class DriverProfile : Profile
    {
        public DriverProfile() 
        {
            CreateMap<DriverForCreationDTO, Driver>().ReverseMap();

            CreateMap<DriverForEditingDTO, Driver>().ReverseMap();

            CreateMap<Driver, DriverDTO>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ReverseMap();
        }

    }
}

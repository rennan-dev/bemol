using AutoMapper;
using WebApi.Data.Dtos;
using WebApi.Models;

namespace WebApi.Profiles;
public class AdminProfile : Profile {

    public AdminProfile() {
        CreateMap<CreateAdminDto, Admin>();
    }
}

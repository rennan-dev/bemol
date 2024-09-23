using AutoMapper;
using WebApi.Data.Dtos;
using WebApi.Models;

namespace WebApi.Profiles; 
public class ClienteProfile : Profile {

    public ClienteProfile() {
        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<Cliente, ReadClienteDto>().ForMember(clienteDto=>clienteDto.Livros, opt=>opt.MapFrom(cliente=>cliente.Livros));
        CreateMap<UpdateClienteDto, Cliente>();
    }
}

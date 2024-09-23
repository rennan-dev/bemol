using AutoMapper;
using WebApi.Data.Dtos;
using WebApi.Models;

namespace WebApi.Profiles; 
public class LivroProfile : Profile {

    public LivroProfile() {
        CreateMap<CreateLivroDto, Livro>();
        CreateMap<Livro, ReadLivroDto>();
        CreateMap<Livro, ReadLivroPorClienteDto>();
        CreateMap<UpdateLivroDto, Livro>();
    }
}

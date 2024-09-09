using AutoMapper;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles; 
public class ProdutoProfile : Profile {

    public ProdutoProfile() {

        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
        CreateMap<Produto, ReadProdutoDto>();
    }
}

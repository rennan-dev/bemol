using AutoMapper;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles; 
public class ProdutoProfile : Profile {

    public ProdutoProfile() {

        CreateMap<CreateProdutoDto, Produto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
        CreateMap<Produto, ReadProdutoDto>().ForMember(produto => produto.ReadCategoriaDto, opt => opt.MapFrom(produto => produto.Categoria));

        CreateMap<CreateEnderecoDto, Endereco>();
        CreateMap<UpdateEnderecoDto, Endereco>();
        CreateMap<Endereco, UpdateEnderecoDto>();
        CreateMap<Endereco, ReadEnderecoDto>();

        CreateMap<CreateClienteDto, Cliente>();
        CreateMap<UpdateClienteDto, Cliente>();
        CreateMap<Cliente, UpdateClienteDto>();
        CreateMap<Cliente, ReadClienteDto>().ForMember(clienteDto => clienteDto.ReadEnderecoDto, opt => opt.MapFrom(cliente => cliente.Endereco));

        CreateMap<CreateCategoriaDto, Categoria>();
        CreateMap<UpdateCategoriaDto, Categoria>();
        CreateMap<Categoria, UpdateCategoriaDto>();
        CreateMap<Categoria, ReadCategoriaDto>();
    }
}

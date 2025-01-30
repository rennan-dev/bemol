using AutoMapper;
using Pedido.Models;
using Microsoft.AspNetCore.Mvc;
using Pedido.Data.ItemPedidoRepository;
using Pedido.Dtos.ItemPedidos;

namespace Estoque.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemPedidoController : ControllerBase {

    private readonly IItemPedidoRepository _repository;
    private readonly IMapper _mapper;

    public ItemPedidoController(IItemPedidoRepository repository, IMapper mapper) {
        _repository = repository;
        _mapper = mapper;
    }

    [HttpGet]
    public ActionResult<IEnumerable<ReadItemPedidoDto>> GetAllItensPedido() {
        var itensPedido = _repository.GetAllItemPedido();
        return Ok(_mapper.Map<IEnumerable<ReadItemPedidoDto>>(itensPedido));
    }

    [HttpGet("{id}", Name = "GetItemPedidoById")]
    public ActionResult<ReadItemPedidoDto> GetItemPedidoById(int id) {
        var itemPedido = _repository.GetItemPedidoById(id);
        if(itemPedido!=null) {
            return Ok(_mapper.Map<ReadItemPedidoDto>(itemPedido));
        }
        return NotFound();
    }
}
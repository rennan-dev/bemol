using System.ComponentModel.DataAnnotations;
using WebApi.Models;

namespace WebApi.Data.Dtos; 
public class ReadClienteDto {

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Cpf { get; set; }
    public ICollection<ReadLivroPorClienteDto> Livros { get; set; }
}

using System.ComponentModel.DataAnnotations;
using ComexAPI.Models;

namespace ComexAPI.Data.Dtos; 
public class ReadProdutoDto {
    
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
    public int CategoriaId { get; set; }
    public ReadCategoriaDto ReadCategoriaDto { get; set; }
}

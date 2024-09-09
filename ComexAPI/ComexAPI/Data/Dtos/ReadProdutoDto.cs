using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos; 
public class ReadProdutoDto {

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public double PrecoUnitario { get; set; }
    public int Quantidade { get; set; }
}

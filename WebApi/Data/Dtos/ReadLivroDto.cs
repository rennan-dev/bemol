using System.ComponentModel.DataAnnotations;

namespace WebApi.Data.Dtos; 
public class ReadLivroDto {

    public int Id { get; set; }
    public string Titulo { get; set; }
    public string Autor { get; set; }
    public string Isbn { get; set; }
    public DateTime DataPublicacao { get; set; }
    public bool EstaEmprestado { get; set; }
}

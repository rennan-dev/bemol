using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos {
    public class CreateClienteDto {
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Profissao { get; set; }
        [Required]
        public string Telefone { get; set; }
        [Required]
        public int EnderecoId { get; set; }
    }
}

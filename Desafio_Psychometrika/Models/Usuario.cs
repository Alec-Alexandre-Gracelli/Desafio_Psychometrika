using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.Models
{
    public class Usuario
    {
        public Guid UsuarioId { get; set; }
        public Guid ProvaSimuladoId { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário!")]
        [StringLength(100)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o e-mail do usuário!")]
        [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
        [StringLength (100)]
        public string Email { get; set; }

        public bool Respondido { get; set; }
    }
}

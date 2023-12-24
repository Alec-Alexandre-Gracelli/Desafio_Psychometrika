using System.ComponentModel.DataAnnotations;

namespace Desafio_Psychometrika.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Digite o nome!")]
        public string Nome { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }

    }
}

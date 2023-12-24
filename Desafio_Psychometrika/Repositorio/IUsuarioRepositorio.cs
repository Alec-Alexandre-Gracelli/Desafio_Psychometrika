using Desafio_Psychometrika.Models;

namespace Desafio_Psychometrika.Repositorio
{
    public interface IUsuarioRepositorio
    {
        Usuario BuscaPorLogin(string login, string mail);
        Usuario Adicionar(Usuario usuario);
    }
}

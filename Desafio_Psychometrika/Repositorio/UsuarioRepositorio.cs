using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Models;

namespace Desafio_Psychometrika.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _context;

        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _context = bancoContext;
        }

        public Usuario BuscaPorLogin(string login, string mail)
        {
            return _context.Usuarios.FirstOrDefault(x => x.Nome.ToUpper() == login.ToUpper() && x.Email.ToUpper() == mail.ToUpper());
        }

        public Usuario Adicionar(Usuario usuarioModel)
        {
            _context.Usuarios.Add(usuarioModel);
            _context.SaveChanges();
            return usuarioModel;
        }
    }
}

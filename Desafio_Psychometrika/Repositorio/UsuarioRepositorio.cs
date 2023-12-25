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
            var novaProva = new ProvaSimulado
            {
                ProvaSimuladoId = new Guid("8ae65f6cd4f64c78997908dc054d9b1c"),
                ProvaNome = "Matemática e suas tecnologias"
            };
            _context.Usuarios.Add(usuarioModel);
            _context.ProvaSimulados.Add(novaProva);
            _context.SaveChanges();
            return usuarioModel;
        }
    }
}

using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Repositorio;

namespace Desafio_Psychometrika.Controllers
{
    public class ControllerBase : Microsoft.AspNetCore.Mvc.Controller
    {
        protected readonly BancoContext _bancoContext;
        protected readonly ISessao _sessao;
        protected readonly IUsuarioRepositorio _usuarioRepositorio;

        public ControllerBase(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio)
        {
            _bancoContext = bancoContext;
            _sessao = sessao;
            _usuarioRepositorio = usuarioRepositorio;
        }
    }
}

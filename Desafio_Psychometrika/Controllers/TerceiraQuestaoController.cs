using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Psychometrika.Controllers
{
    public class TerceiraQuestaoController : ControllerBase
    {
        public TerceiraQuestaoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}

using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Psychometrika.Controllers
{
    public class SegundaQuestaoController : ControllerBase
    {
        public SegundaQuestaoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(UsuarioProva usuarioProva)
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            usuarioProva.UsuarioId = usuarioLogado.UsuarioId;
            usuarioProva.ProvaSimuladoId = _bancoContext.ProvaSimulados.Where(p => p.ProvaNome == "Matemática e suas tecnologias")
                                                                       .Select(s => s.ProvaSimuladoId)
                                                                       .FirstOrDefault();
            var questao = _bancoContext.Questoes
                           .Where(x => x.Questao == 2)
                           .Select(s => s.QuestoesId)
                           .FirstOrDefault();

            usuarioProva.QuestoesId = questao;
            usuarioProva.Respondido = true;

            _bancoContext.UsuarioProvas.Add(usuarioProva);
            //_bancoContext.SaveChanges();
            return View();
        }
    }
}

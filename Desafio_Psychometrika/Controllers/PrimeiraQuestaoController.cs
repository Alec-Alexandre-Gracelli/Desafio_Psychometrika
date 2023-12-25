using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Psychometrika.Controllers
{
    public class PrimeiraQuestaoController : ControllerBase
    {
        public PrimeiraQuestaoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(ProvaSimulado provaSimulado)
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            provaSimulado.UsuarioId = usuarioLogado.UsuarioId;
            provaSimulado.ProvaSimuladoId = new Guid("3a07ecc9-d651-46e2-884b-a6a085f49bc6");
            provaSimulado.ProvaNome = "Matemática e suas tecnologias";

            var questao = _bancoContext.Questoes
                           .Where(x => x.Questao == 1)
                           .Select(s => s.QuestoesId)
                           .FirstOrDefault();

            provaSimulado.QuestoesId = questao;

            if (provaSimulado.Resposta != null)
            {
                provaSimulado.Respondido = true;
            }
            _bancoContext.ProvaSimulados.Add(provaSimulado);
            //_bancoContext.SaveChanges();
            return View();
        }
    }
}

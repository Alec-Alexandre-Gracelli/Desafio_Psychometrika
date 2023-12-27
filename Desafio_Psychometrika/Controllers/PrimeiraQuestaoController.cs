using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Desafio_Psychometrika.Controllers
{
    public class PrimeiraQuestaoController : ControllerBase
    {
        public PrimeiraQuestaoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UsuarioProva usuarioProva)
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            usuarioProva.UsuarioId = usuarioLogado.UsuarioId;
            usuarioProva.ProvaSimuladoId = await _bancoContext.ProvaSimulados.Where(p => p.ProvaNome == "Matemática e suas tecnologias")
                                                                       .Select(s => s.ProvaSimuladoId)
                                                                       .FirstOrDefaultAsync();
            var questao = await _bancoContext.Questoes
                           .Where(x => x.Questao == 1)
                           .Select(s => s.QuestoesId)
                           .FirstOrDefaultAsync();

            usuarioProva.QuestoesId = questao;
            usuarioProva.Respondido = true;

            
            if (usuarioProva.Resposta == null)
            {
                usuarioProva.Resposta = null;
                usuarioProva.Respondido = false;
                _bancoContext.UsuarioProvas.Add(usuarioProva);
                await _bancoContext.SaveChangesAsync();
            }
            else
            {
                usuarioProva.Resposta = usuarioProva.Resposta;
                usuarioProva.Respondido = usuarioProva.Respondido;
                _bancoContext.UsuarioProvas.Add(usuarioProva);
                await _bancoContext.SaveChangesAsync();
            }
            if (usuarioProva.Respondido)
            {
                TempData["MensagemSucesso"] = "Resposta salva com sucesso!";
                return RedirectToAction("Index", "SegundaQuestao");
            }
            return RedirectToAction("Index", "SegundaQuestao");
        }
    }
}

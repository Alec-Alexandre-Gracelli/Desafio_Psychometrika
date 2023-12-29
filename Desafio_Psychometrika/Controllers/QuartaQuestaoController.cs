using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Psychometrika.Controllers
{
    public class QuartaQuestaoController : ControllerBase
    {
        public QuartaQuestaoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public async Task<IActionResult> Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();

            var existeUsuarioProvas = _bancoContext.UsuarioProvas
                                        .Where(x => x.UsuarioId == usuarioLogado.UsuarioId && x.ProvaSimuladoId == _bancoContext.ProvaSimulados
                                        .Where(p => p.ProvaNome == "Ciências da Natureza e suas tecnologias")
                                        .Select(s => s.ProvaSimuladoId)
                                        .FirstOrDefault() && x.QuestoesId == _bancoContext.Questoes
                                        .Where(x => x.Questao == 4)
                                        .Select(s => s.QuestoesId)
                                        .FirstOrDefault())
                                        .ToList();
            if (existeUsuarioProvas != null)
            {
                _bancoContext.UsuarioProvas.RemoveRange(existeUsuarioProvas);
                await _bancoContext.SaveChangesAsync();
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UsuarioProva usuarioProva)
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();
            usuarioProva.UsuarioId = usuarioLogado.UsuarioId;
            usuarioProva.ProvaSimuladoId = await _bancoContext.ProvaSimulados.Where(p => p.ProvaNome == "Ciências da Natureza e suas tecnologias")
                                                                       .Select(s => s.ProvaSimuladoId)
                                                                       .FirstOrDefaultAsync();
            var questao = await _bancoContext.Questoes
                           .Where(x => x.Questao == 4)
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
                return RedirectToAction("Index", "Gabarito");
            }
            return RedirectToAction("Index", "Gabarito");
        }

        public async Task<IActionResult> Editar()
        {
            return View();
        }
    }
}

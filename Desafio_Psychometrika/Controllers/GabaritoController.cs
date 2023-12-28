using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Desafio_Psychometrika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Psychometrika.Controllers
{
    public class GabaritoController : ControllerBase
    {
        public GabaritoController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public async Task<IActionResult> Index()
        {
            Usuario usuarioLogado = _sessao.BuscarSessaoDoUsuario();

            var listaResposta = await _bancoContext.UsuarioProvas.Where(x => x.UsuarioId == usuarioLogado.UsuarioId)
                                                           .Select(s => s.Resposta).ToListAsync();

            var ListaRespondido = await _bancoContext.UsuarioProvas.Where(x => x.UsuarioId == usuarioLogado.UsuarioId)
                                                              .Select(s => s.Respondido).ToListAsync();

            var listaControllerAction = new List<Tuple<string, string>>
            {
                Tuple.Create("PrimeiraQuestao", "Editar"),
                Tuple.Create("SegundaQuestao", "Editar"),
                Tuple.Create("TerceiraQuestao", "Editar"),
                Tuple.Create("QuartaQuestao", "Editar"),
            };

            var gabaritoUsuario = new GabaritoViewModel
            {
                Resposta = listaResposta,
                Respondido = ListaRespondido,
                ControllerActionList = listaControllerAction
            };

            ViewBag.GabaritoUsuario = gabaritoUsuario;

            return View();
        }
    }
}

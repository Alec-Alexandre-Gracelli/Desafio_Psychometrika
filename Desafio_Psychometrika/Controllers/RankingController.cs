using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models.Enum;
using Desafio_Psychometrika.Repositorio;
using Desafio_Psychometrika.Utilities;
using Desafio_Psychometrika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Psychometrika.Controllers
{
    public class RankingController : ControllerBase
    {
        public RankingController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public async Task<IActionResult> Index(int? page)
        {
            var listaUsuarios = await _bancoContext.Usuarios.ToListAsync();

            var questoesIds = await _bancoContext.Questoes
                               .Select(q => q.QuestoesId)
                               .ToListAsync();

            var paginaAtual = page ?? 1;

            var ranking = new List<RankingViewModel>();

            foreach (var usuario in listaUsuarios)
            {
                var respostasUsuario = await _bancoContext.UsuarioProvas
                    .Where(x => x.UsuarioId == usuario.UsuarioId && questoesIds.Contains(x.QuestoesId))
                    .Select(s => s.Resposta)
                    .ToListAsync();

                var nota = CalcularNota(respostasUsuario);

                ranking.Add(new RankingViewModel
                {
                    NomeUsuario = usuario.Nome,
                    Nota = nota
                });
            }

            ranking = ranking.OrderByDescending(x => x.Nota).ToList();

            var itensPorPagina = 5;

            var paginacao = Paginacao<RankingViewModel>.Criar(ranking, paginaAtual, itensPorPagina);

            return View(paginacao);
        }



        private double CalcularNota(List<Resposta?> respostasUsuario)
        {
            var gabarito = _bancoContext.Gabaritos.Select(x => x.RespostaCorreta).ToList();

            double nota = 0.0F;
            for (int i = 0; i < respostasUsuario.Count; i++)
            {
                if (respostasUsuario[i] == gabarito[i])
                {
                    nota += 25.0F;
                }
            }

            return nota;
        }

    }
}

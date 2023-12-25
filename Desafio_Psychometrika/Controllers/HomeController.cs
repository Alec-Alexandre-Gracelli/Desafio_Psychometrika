using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Desafio_Psychometrika.Controllers
{
    public class HomeController : Controller
    {
        private readonly BancoContext _bancoContext;
        public HomeController(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public IActionResult Questao1()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Questao1(ProvaSimulado provaSimulado)
        {
            var questao = _bancoContext.Questoes.Where(x => x.Questao == 1)
                           .Select(s => s.QuestoesId).FirstOrDefault();

            if(provaSimulado.Resposta != null)
            {
                provaSimulado.Respondido = true;
            }

            provaSimulado = new ProvaSimulado
            {
                ProvaSimuladoId = new Guid("3a07ecc9-d651-46e2-884b-a6a085f49bc6"),
                ProvaNome = "Matemática e suas tecnologias",
                QuestoesId = questao,
            };
            _bancoContext.ProvaSimulados.Add(provaSimulado);
            return View();
        }
        public IActionResult Questao2()
        {
            return View();
        }

        public IActionResult Questao3()
        {
            return View();
        }
        public IActionResult Questao4()
        {
            return View();
        }

        public IActionResult Gabarito()
        {
            return View();
        }
    }
}
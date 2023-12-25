using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Models;
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

        //[HttpPost]
        //public IActionResult Questao1(ProvaSimulado provaSimulado)
        //{
        //    provaSimulado.
        //    return View();
        //}
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
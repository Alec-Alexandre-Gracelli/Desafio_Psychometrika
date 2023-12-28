using Desafio_Psychometrika.Data;
using Desafio_Psychometrika.Helper;
using Desafio_Psychometrika.Models;
using Desafio_Psychometrika.Repositorio;
using Desafio_Psychometrika.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Psychometrika.Controllers
{
    public class LoginController : ControllerBase
    {
        public LoginController(BancoContext bancoContext, ISessao sessao, IUsuarioRepositorio usuarioRepositorio) : base(bancoContext, sessao, usuarioRepositorio)
        {
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Entrar(LoginViewModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    Usuario usuario =  _usuarioRepositorio.BuscaPorLogin(loginModel.Nome, loginModel.Email);

                    if (usuario != null)
                    {
                        _sessao.CriarSessaoDoUsuario(usuario);
                        return RedirectToAction("Index", "PrimeiraQuestao");
                    }
                }
                TempData["MensagemErro"] = $"Nome e/ou Email inválido(s). Por favor, tente novamente.";


                return View("Index");
            }
            catch (Exception erro) 
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar seu login, tente novamente, detalhe do erro: {erro.Message}";
                    return RedirectToAction("Index");
            }
        }

        public async Task<IActionResult> Cadastro()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastro(Usuario usuarioModel) 
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if(usuarioModel != null)
                    {
                        _usuarioRepositorio.Adicionar(usuarioModel);
                        TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                        return RedirectToAction("Index");
                    }
                }
                return View(usuarioModel);
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Sair()
        {
            _sessao.RemoverSessaoDoUsuario();

            return RedirectToAction("Index");
        }
    }
}

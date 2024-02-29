using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers;

public class LoginController(IUsuarioRepository repository) : Controller
{
    private readonly IUsuarioRepository _repository = repository;
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Entrar(LoginModel loginModel)
    {
        try
        {
            if (ModelState.IsValid)
            {
                var usuario = _repository.BuscarPorLogin(loginModel.Login);
                bool senhaValida = usuario.SenhaValida(loginModel.Senha);

                if (usuario != null)
                {
                    if (senhaValida)
                    {
                        return RedirectToAction("Index", "Home");
                    }

                    TempData["MensagemError"] = $"Senha do usuário é inválida. Por favor, tente novamente.";
                    return View("Index");
                }

                TempData["MensagemError"] = $"Usuário e/ou senha inválido(s). Por favor, tente novamente.";
            }

            return View("Index");
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos realizar o login, tente novamente, detalhes do error: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}

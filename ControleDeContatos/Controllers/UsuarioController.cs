using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers;

public class UsuarioController(IUsuarioRepository repository) : Controller
{
    private readonly IUsuarioRepository _repository = repository;

    public IActionResult Index()
    {
        var usuarios = _repository.BuscarTodos();

        return View(usuarios);
    }
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Criar(UsuarioModel usuario)
    {
        try
        {
            if (ModelState.IsValid)
            {
                usuario = _repository.Adicionar(usuario);

                TempData["MensagemSucesso"] = "Usuário cadastrado com sucesso!";
                return RedirectToAction("Index");
            }

            return View(usuario);
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos cadastrar seu usuário, tente novamente, detalhe do erro: {error.Message}";
            return RedirectToAction("Index");
        }
    }
    public IActionResult Editar(int id)
    {
        var usuario = _repository.BuscarPorId(id);

        return View(usuario);
    }
    public IActionResult ApagarConfirmacao(int id)
    {
        var usuario = _repository.BuscarPorId(id);

        return View(usuario);
    }
    [HttpPost]
    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _repository.Apagar(id);

            if (apagado)
                TempData["MensagemSucesso"] = "Usuário apagado com sucesso!";
            else
                TempData["MensagemError"] = "Ops, aconteceu algo de errado, não foi possível apagar o usuário!";

            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, aconteceu algo de errado, mais detalhes do error: {error.Message}";

            return RedirectToAction("Index");
        }
    }
    [HttpPost]
    public IActionResult Atualizar(UsuarioSemSenhaModel usuarioSemSenhaModel)
    {
        UsuarioModel? usuario = null;

        try
        {
            if (ModelState.IsValid)
            {
                usuario = new UsuarioModel()
                {
                    Email = usuarioSemSenhaModel.Email,
                    Nome = usuarioSemSenhaModel.Nome,
                    Login = usuarioSemSenhaModel.Login,
                    Perfil = usuarioSemSenhaModel.Perfil,
                    Id = usuarioSemSenhaModel.Id
                };

                usuario = _repository.Atualizar(usuario);
                TempData["MensagemSucesso"] = "Usuário atualizado com sucesso!";

                return RedirectToAction("Index");
            }

            return View("Editar", usuario);
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos atualizar seu usuario, tente novamente, detalhe do error: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}

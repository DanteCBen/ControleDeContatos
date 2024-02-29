using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContatos.Controllers;
public class ContatoController : Controller
{
    private readonly IContatoRepository _contatoRepository;
    public ContatoController(IContatoRepository contatoRepository)
    {
        _contatoRepository = contatoRepository;
    }
    public IActionResult Index()
    {
        var contatos = _contatoRepository.BuscarTodos();

        return View(contatos);
    }

    public IActionResult Criar()
    {
        return View();
    }

    public IActionResult Editar(int id)
    {
        var contato = _contatoRepository.ListarPorId(id);

        return View(contato);
    }

    public IActionResult ApagarConfirmacao(int id)
    {
        var contato = _contatoRepository.ListarPorId(id);

        return View(contato);
    }

    [HttpPost]
    public IActionResult Apagar(int id)
    {
        try
        {
            bool apagado = _contatoRepository.Apagar(id);

            if (apagado)
            {
                TempData["MensagemSucesso"] = "Contato Apagado com Sucesso!!!";
            }
            else
            {
                TempData["MensagemError"] = "Ops, não conseguimos apagar seu contato!";
            }

            return RedirectToAction("Index");
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos apagar seu contato, mais detalhes do error: {error.Message}";
            return RedirectToAction("Ïndex");
        }


    }

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Adicionar(contato);
                TempData["MensagemSucesso"] = "Contato Cadastrado com Sucesso!!!";
                return RedirectToAction("Index");
            }

            return View(contato);
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos cadastrar seu contato, tente novamente, detalhe do erro:{error.Message}";
            return RedirectToAction("Index");
        }
    }

    [HttpPost]
    public IActionResult Atualizar(ContatoModel contato)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _contatoRepository.Atualizar(contato);
                TempData["MensagemSucesso"] = "Contato Atualizado com Sucesso!!!";
                return RedirectToAction("Index");
            }

            return View("Editar", contato);
        }
        catch (Exception error)
        {
            TempData["MensagemError"] = $"Ops, não conseguimos atualizar seu contato, tente novamente, detalhe do error: {error.Message}";
            return RedirectToAction("Index");
        }
    }
}

using ControleDeContatos.Models;
using ControleDeContatos.Repository;
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
        _contatoRepository.Apagar(id)

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Criar(ContatoModel contato)
    {
        _contatoRepository.Adicionar(contato);

        return RedirectToAction("Index");
    }

    [HttpPost]
    public IActionResult Atualizar(ContatoModel contato)
    {
        _contatoRepository.Atualizar(contato);

        return RedirectToAction("Index");
    }
}

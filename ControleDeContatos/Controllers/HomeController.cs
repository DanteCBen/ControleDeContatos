using Microsoft.AspNetCore.Mvc;
using ControleDeContatos.Filters;

namespace ControleDeContatos.Controllers;
public class HomeController : Controller
{
    [PaginaParaUsuarioLogado]
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

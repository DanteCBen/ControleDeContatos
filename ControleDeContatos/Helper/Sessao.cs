using ControleDeContatos.Interfaces;
using ControleDeContatos.Models;
using Newtonsoft.Json;

namespace ControleDeContatos.Helper;
public class Sessao(IHttpContextAccessor httpContext) : ISessao
{
    private readonly IHttpContextAccessor _httpContext = httpContext;

    public UsuarioModel? BuscarSessaoDoUsuario()
    {
        string sessaoUsuario = _httpContext.HttpContext?.Session.GetString("sessaoUsuarioLogado")!;

        if (string.IsNullOrEmpty(sessaoUsuario)) return null;

        return JsonConvert.DeserializeObject<UsuarioModel>(sessaoUsuario);
    }

    public void CriarSessaoDoUsuario(UsuarioModel usuario)
    {
        string valor = JsonConvert.SerializeObject(usuario);

        _httpContext.HttpContext?.Session.SetString("sessaoUsuarioLogado", valor);
    }

    public void RemoverSessaoDoUsuario()
    {
        _httpContext.HttpContext?.Session.Remove("sessaoUsuarioLogado");
    }
}
using ControleDeContatos.Models;

namespace ControleDeContatos.Interfaces;
public interface ISessao
{
    void CriarSessaoDoUsuario(UsuarioModel usuario);
    void RemoverSessaoDoUsuario();
    UsuarioModel? BuscarSessaoDoUsuario();
}
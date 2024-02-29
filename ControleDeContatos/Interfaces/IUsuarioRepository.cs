using ControleDeContatos.Models;

namespace ControleDeContatos.Interfaces;

public interface IUsuarioRepository
{
    List<UsuarioModel> BuscarTodos();
    UsuarioModel BuscarPorId(int id);
    UsuarioModel Adicionar(UsuarioModel usuario);
    UsuarioModel Atualizar(UsuarioModel usuario);
    UsuarioModel BuscarPorLogin(string login);
    bool Apagar(int id);
}

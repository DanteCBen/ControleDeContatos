using ControleDeContatos.Data;
using ControleDeContatos.Models;
using ControleDeContatos.Interfaces;

namespace ControleDeContatos.Repository;
public class UsuarioRepository(BancoContext bancoContext) : IUsuarioRepository
{
    private readonly BancoContext _bancoContext = bancoContext;

    public UsuarioModel Adicionar(UsuarioModel usuario)
    {
        usuario.DataDeCadastro = DateTime.Now;

        usuario.SetHashPassword();

        _bancoContext.Usuarios.Add(usuario);
        _bancoContext.SaveChanges();

        return usuario;
    }

    public bool Apagar(int id)
    {
        var usuario = _bancoContext.Usuarios.Find(id);

        if (usuario == null) throw new Exception("Error ao tentar deletar este usuário!");

        _bancoContext.Remove(usuario);
        _bancoContext.SaveChanges();

        return true;
    }

    public UsuarioModel Atualizar(UsuarioModel usuario)
    {
        var usuarioBuscado = BuscarPorId(usuario.Id);

        if (usuarioBuscado == null) throw new Exception("Houve um erro na atualização do contato");

        usuarioBuscado.Nome = usuario.Nome;
        usuarioBuscado.Email = usuario.Email;
        usuarioBuscado.Login = usuario.Login;
        usuarioBuscado.Perfil = usuario.Perfil;
        usuarioBuscado.DataDeAtualizacao = DateTime.Now;

        _bancoContext.Usuarios.Update(usuarioBuscado);
        _bancoContext.SaveChanges();

        return usuarioBuscado;
    }

    public UsuarioModel BuscarPorId(int id) => _bancoContext.Usuarios.Find(id)!;

    public UsuarioModel BuscarPorLogin(string login)
    {
        var usuario = _bancoContext.Usuarios.FirstOrDefault(usuario => usuario.Login.ToUpper() == login.ToUpper());

        return usuario;
    }

    public List<UsuarioModel> BuscarTodos() => _bancoContext.Usuarios.ToList();
}
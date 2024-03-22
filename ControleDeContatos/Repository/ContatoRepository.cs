using ControleDeContatos.Data;
using ControleDeContatos.Models;

namespace ControleDeContatos.Repository;

public class ContatoRepository : IContatoRepository
{
    private readonly BancoContext _bancoContext;
    public ContatoRepository(BancoContext bancoContext)
    {
        _bancoContext = bancoContext;
    }
    public ContatoModel Adicionar(ContatoModel contato)
    {
        _bancoContext.Contatos.Add(contato);
        _bancoContext.SaveChanges();

        return contato;
    }

    public bool Apagar(int id)
    {
        var contato = ListarPorId(id);

        if (contato == null) throw new Exception("Erro ao apagar o contato.");

        _bancoContext.Remove(contato);
        _bancoContext.SaveChanges();

        return true;
    }

    public ContatoModel Atualizar(ContatoModel contato)
    {
        var contatoBuscado = ListarPorId(contato.Id);

        if (contatoBuscado == null) throw new Exception("Houve um erro na atualização do contato.");

        contatoBuscado.Nome = contato.Nome;
        contatoBuscado.Email = contato.Email;
        contatoBuscado.Celular = contato.Celular;

        _bancoContext.Contatos.Update(contatoBuscado);
        _bancoContext.SaveChanges();

        return contatoBuscado;
    }

    public List<ContatoModel> BuscarTodos()
    {
        var allContatos = _bancoContext.Contatos.ToList();

        return allContatos;
    }

    public ContatoModel ListarPorId(int id)
    {
        var contato = _bancoContext.Contatos.FirstOrDefault(contato => contato.Id == id);

        return contato!;
    }
}

using ControleDeContatos.Models;

namespace ControleDeContatos.Interfaces;

public interface IContatoRepository
{
    ContatoModel Adicionar(ContatoModel contato);
    ContatoModel ListarPorId(int id);
    ContatoModel Atualizar(ContatoModel contato);
    bool Apagar(int id);
    List<ContatoModel> BuscarTodos();

}

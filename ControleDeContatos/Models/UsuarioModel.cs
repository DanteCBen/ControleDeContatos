using System.ComponentModel.DataAnnotations;
using ControleDeContatos.Enums;

namespace ControleDeContatos.Models;

public class UsuarioModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Digite o nome do usuário.")]
    public required string Nome { get; set; }

    [Required(ErrorMessage = "Digite o login do usuário.")]
    public required string Login { get; set; }

    [Required(ErrorMessage = "Digite o email do usuário.")]
    [EmailAddress(ErrorMessage = "O e-mail informado não é válido!")]
    public required string Email { get; set; }

    [Required(ErrorMessage = "Digite a senha do usuário.")]
    public required string Senha { get; set; }
    public DateTime DataDeCadastro { get; set; }
    public DateTime? DataDeAtualizacao { get; set; }
    public PerfilEnum Perfil { get; set; }

}

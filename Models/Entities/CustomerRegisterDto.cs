using System.ComponentModel.DataAnnotations;

// * Só faz sentido tornar obrigatório (required) no cadastro de um novo cliente. De outra forma ao tentar atualizar, todas as propriedades seriam requeridas.
public class CustomerRegisterDto
{
    public required string Name { get; set; }

    [EmailAddress]
    public required string Email { get; set; }

    public required string Password { get; set; }
}
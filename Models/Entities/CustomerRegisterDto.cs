using System.ComponentModel.DataAnnotations;

// * Só faz sentido tornar obrigatório (required) no cadastro de um novo cliente. De outra forma ao tentar atualizar, todas as propriedades seriam requeridas.
public class CustomerRegisterDto
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}
// * Em um projeto de maior robustez eu poderia utilizar o EntityTypeConfiguration para o mapear e assim manter uma maior organização, mas criar isso aqui traria uma complexidade desnecessária.
using System.ComponentModel.DataAnnotations;
public class Customer
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid(); 
    public string? Name { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }
    public string? Role { get; set; }
}
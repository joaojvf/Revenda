using System.ComponentModel.DataAnnotations;

namespace Revenda.Core.Entities;

public class NomeContato
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Nome do contato é obrigatório.")]
    [MaxLength(100)]
    public required string Nome { get; set; }

    public bool IsPrincipal { get; set; } // Regra de "apenas um principal" -> FluentValidation ou lógica no Command Handler

    [Required]
    public Guid RevendaId { get; set; }
    public virtual RevendaEntity Revenda { get; set; } = null!;
}

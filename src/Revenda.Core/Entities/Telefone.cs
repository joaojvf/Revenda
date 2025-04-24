using System.ComponentModel.DataAnnotations;

namespace Revenda.Core.Entities;
public class Telefone
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    [MaxLength(20)]
    public required string Numero { get; set; }

    [Required]
    public Guid RevendaId { get; set; }
    public virtual RevendaEntity Revenda { get; set; } = null!;
}


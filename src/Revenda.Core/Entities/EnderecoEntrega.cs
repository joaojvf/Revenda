using System.ComponentModel.DataAnnotations;

namespace Revenda.Core.Entities;

public class EnderecoEntrega
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "Logradouro é obrigatório.")]
    [MaxLength(200)]
    public required string Logradouro { get; set; }

    [MaxLength(20)]
    public string? Numero { get; set; } // Pode não ter número

    [MaxLength(100)]
    public string? Complemento { get; set; }

    [Required(ErrorMessage = "Bairro é obrigatório.")]
    [MaxLength(100)]
    public required string Bairro { get; set; }

    [Required(ErrorMessage = "Cidade é obrigatória.")]
    [MaxLength(100)]
    public required string Cidade { get; set; }

    [Required(ErrorMessage = "Estado é obrigatório.")]
    [StringLength(2, MinimumLength = 2, ErrorMessage = "Estado deve ter 2 caracteres.")]
    public required string Estado { get; set; }

    [Required(ErrorMessage = "CEP é obrigatório.")]
    [RegularExpression(@"^\d{8}$", ErrorMessage = "CEP deve conter 8 dígitos numéricos.")]
    public required string Cep { get; set; }

    [Required]
    public Guid RevendaId { get; set; }
    public virtual RevendaEntity Revenda { get; set; } = null!;
}

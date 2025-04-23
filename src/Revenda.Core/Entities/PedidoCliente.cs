using System.ComponentModel.DataAnnotations;
namespace Revenda.Core.Entities;

public class PedidoCliente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid RevendaId { get; set; }
    public virtual RevendaEntity Revenda { get; set; } = null!;

    [Required(ErrorMessage = "Identificação do cliente é obrigatória.")]
    [MaxLength(100)]
    public required string IdentificacaoCliente { get; set; }

    public DateTime DataPedido { get; set; } = DateTime.UtcNow;

    public virtual ICollection<ItemPedidoCliente> Itens { get; set; } = new List<ItemPedidoCliente>();
}

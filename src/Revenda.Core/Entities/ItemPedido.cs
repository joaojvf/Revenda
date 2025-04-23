using System.ComponentModel.DataAnnotations;

namespace Revenda.Core.Entities;

public class ItemPedido
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid PedidoId { get; set; }
    public virtual Pedido Pedido { get; set; } = null!;

    [Required]
    [MaxLength(50)]
    public required string ProdutoId { get; set; }

    [Range(1, int.MaxValue)]
    public int Quantidade { get; set; }
}


using System.ComponentModel.DataAnnotations;

namespace Revenda.Core.Entities;

public class ItemPedidoCliente
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid PedidoClienteId { get; set; }
    public virtual PedidoCliente PedidoCliente { get; set; } = null!;

    [Required(ErrorMessage = "ID do produto é obrigatório.")]
    [MaxLength(50)]
    public required string ProdutoId { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser pelo menos 1.")]
    public int Quantidade { get; set; }
}

public record ItemPedidoClienteGrouped(string ProdutoId, int Quantidade);
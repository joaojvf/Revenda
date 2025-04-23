using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Revenda.Core.Entities;

public class Pedido
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required]
    public Guid RevendaId { get; set; }
    public virtual RevendaEntity Revenda { get; set; } = null!;

    public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
    public DateTime? DataEnvio { get; set; }
    public StatusPedido Status { get; set; } = StatusPedido.Pendente;
    public string? OrderId { get; set; } // ID retornado pela API mockada
    public int TentativasEnvio { get; set; } = 0;

    [NotMapped]
    public int QuantidadeTotal => Itens.Sum(i => i.Quantidade);

    // Se a  precisar saber os itens, mesmo sem os clientes:
    public virtual ICollection<ItemPedido> Itens { get; set; } = new List<ItemPedido>();

}

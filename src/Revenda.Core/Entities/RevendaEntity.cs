using System.ComponentModel.DataAnnotations;
namespace Revenda.Core.Entities;

public class RevendaEntity
{
    [Key]
    public Guid Id { get; set; } = Guid.NewGuid();

    [Required(ErrorMessage = "CNPJ é obrigatório.")]
    [StringLength(14)]
    public required string Cnpj { get; set; }

    [Required(ErrorMessage = "Razão Social é obrigatória.")]
    [MaxLength(200)]
    public required string RazaoSocial { get; set; }

    [Required(ErrorMessage = "Nome Fantasia é obrigatório.")]
    [MaxLength(150)]
    public required string NomeFantasia { get; set; }

    [Required(ErrorMessage = "Email é obrigatório.")]
    [EmailAddress(ErrorMessage = "Formato de email inválido.")]
    [MaxLength(100)]
    public required string Email { get; set; }

    public virtual ICollection<Telefone> Telefones { get; set; } = new List<Telefone>();
    public virtual ICollection<NomeContato> NomesContato { get; set; } = new List<NomeContato>();
    public virtual ICollection<EnderecoEntrega> EnderecosEntrega { get; set; } = new List<EnderecoEntrega>();
    public virtual ICollection<PedidoCliente> PedidosCliente { get; set; } = new List<PedidoCliente>();
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}


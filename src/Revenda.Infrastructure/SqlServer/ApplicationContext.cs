using Microsoft.EntityFrameworkCore;
using Revenda.Core.Entities;
using Revenda.Core.Helpers;

public class ApplicationContext(DbContextOptions<ApplicationContext> options) : DbContext(options)
{
    public DbSet<RevendaEntity> Revendas => Set<RevendaEntity>();
    public DbSet<PedidoCliente> PedidosCliente => Set<PedidoCliente>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();

    public DbSet<Telefone> Telefones => Set<Telefone>();
    public DbSet<NomeContato> NomesContato => Set<NomeContato>();
    public DbSet<EnderecoEntrega> EnderecosEntrega => Set<EnderecoEntrega>();
    public DbSet<ItemPedidoCliente> ItensPedidoCliente => Set<ItemPedidoCliente>();
    public DbSet<ItemPedido> ItensPedido => Set<ItemPedido>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Seed Data
        modelBuilder.Entity<RevendaEntity>().HasData(DefaultSeedData.DefaultRevendas);
        modelBuilder.Entity<Telefone>().HasData(DefaultSeedData.DefaultTelefones);
        modelBuilder.Entity<NomeContato>().HasData(DefaultSeedData.DefaultNomesContato);
        modelBuilder.Entity<EnderecoEntrega>().HasData(DefaultSeedData.DefaultEnderecosEntrega);
        modelBuilder.Entity<PedidoCliente>().HasData(DefaultSeedData.DefaultPedidosCliente);
        modelBuilder.Entity<ItemPedidoCliente>().HasData(DefaultSeedData.DefaultItensPedidoCliente);
        modelBuilder.Entity<Pedido>().HasData(DefaultSeedData.DefaultPedidos);

        modelBuilder.Entity<ItemPedido>().HasData(DefaultSeedData.DefaultItensPedido);
        base.OnModelCreating(modelBuilder);
    }
}

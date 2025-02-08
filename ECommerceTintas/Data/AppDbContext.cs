﻿using ECommerceTintas.Models.MaterialDePintura;
using ECommerceTintas.Models.Pedidos;
using ECommerceTintas.Models.Produtos;
using ECommerceTintas.Models.Tinta;
using ECommerceTintas.Models.Usuario;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<UsuarioModel> Usuarios { get; set; }
    public DbSet<ProdutoModel> Produtos { get; set; }
    public DbSet<TintaModel> Tintas { get; set; }  
    public DbSet<MaterialDePinturaModel> MateriaisDePintura { get; set; }
    public DbSet<PedidoModel> Pedidos { get; set; }
    public DbSet<ItemPedidoModel> ItensPedido { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<ProdutoModel>().ToTable("Produtos");
        modelBuilder.Entity<TintaModel>().ToTable("Tintas");
        modelBuilder.Entity<MaterialDePinturaModel>().ToTable("MateriaisDePintura");
    }
}
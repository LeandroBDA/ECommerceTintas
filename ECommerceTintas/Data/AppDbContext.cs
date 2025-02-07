using ECommerceTintas.Models.MaterialDePintura;
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
}
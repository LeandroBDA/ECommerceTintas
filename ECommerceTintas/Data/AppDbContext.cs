using ECommerceTintas.Models.Produto;
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
}
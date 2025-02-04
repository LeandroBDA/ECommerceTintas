using ECommerceTintas.Models;
using Microsoft.EntityFrameworkCore;

namespace ECommerceTintas.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    
    public DbSet<ClienteModel> Clientes { get; set; }
}
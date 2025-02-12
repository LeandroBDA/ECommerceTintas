using ECommerceTintas.Data;
using ECommerceTintas.Services.ItemPedido;
using ECommerceTintas.Services.MaterialDePintura;
using ECommerceTintas.Services.Pedido;
using ECommerceTintas.Services.Produto;
using ECommerceTintas.Services.Tinta;
using ECommerceTintas.Services.Usuarios;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione esta linha para o serviço de autorização
builder.Services.AddAuthorization();

builder.Services.AddScoped<ITintaInterface, TintaService>();
builder.Services.AddScoped<IPedidoInterface, PedidoService>();
builder.Services.AddScoped<IProdutoInterface, ProdutoService>();
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();
builder.Services.AddScoped<IItemPedidoInterface, ItemPedidoService>();
builder.Services.AddScoped<IMaterialDePinturaInterface, MaterialDePinturaService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Configuração do CORS - permitindo requisições de qualquer origem
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()  // Permite qualquer origem (ajuste conforme necessário)
              .AllowAnyMethod()  // Permite qualquer método HTTP (GET, POST, etc.)
              .AllowAnyHeader(); // Permite qualquer cabeçalho
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Aplica a política de CORS configurada
app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
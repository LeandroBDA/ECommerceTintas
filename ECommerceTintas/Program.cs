using ECommerceTintas.Data;
using ECommerceTintas.Services.Cliente;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Adicione esta linha para o serviço de autorização
builder.Services.AddAuthorization();

//builder.Services.AddScoped<IprodutosInterface, ProdutosService>(); // Voçe vai acrescentar apenas isso, e assim pras outras entidades
builder.Services.AddScoped<IUsuarioInterface, UsuarioService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefautConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


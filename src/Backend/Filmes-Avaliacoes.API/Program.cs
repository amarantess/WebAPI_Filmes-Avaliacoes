using Filmes_Avaliacoes.Application.Services;
using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;
using Filmes_Avaliacoes.Application.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddScoped<IFilmeInterface, FilmeService>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Registro do middleware personalizado de tratamento de exceções
app.UseMiddleware<ExceptionMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();

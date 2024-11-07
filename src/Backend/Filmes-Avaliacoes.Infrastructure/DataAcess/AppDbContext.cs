using Filmes_Avaliacoes.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Filmes_Avaliacoes.Infrastructure.DataAcess
{
	public class AppDbContext : DbContext
	{
        public AppDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Filme> Filmes { get; set; }
    }
}

using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Domain.Entities;
using Filmes_Avaliacoes.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Filmes_Avaliacoes.Application.Services
{
	public class FilmeService : IFilmeInterface
	{
        private readonly AppDbContext _context;

        // Construtor
        public FilmeService(AppDbContext context)
        {
            _context = context;
        }

        // Implementando os métodos
        public async Task<Response<List<Filme>>> ListarAutores()
		{
			Response<List<Filme>> resposta = new Response<List<Filme>>();

            try
            {
                var filmes = await _context.Filmes.ToListAsync();

                resposta.Dados = filmes;
                resposta.Mensagem = "Todos os filmes foram encontrados";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

		}


	}
}

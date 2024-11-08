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

		public async Task<Response<Filme>> BuscarFilmePorId(int idFilme)
		{
			Response<Filme> resposta = new Response<Filme>();

            try
            {
                var filme = await _context.Filmes.FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme);

                if (filme == null)
                {
                    resposta.Mensagem = "Nenhum registro encontrado";
                    return resposta;
                }

                resposta.Dados = filme;
                resposta.Mensagem = "Filme localizado";
                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

		}

		public async Task<Response<List<Filme>>> ListarFilmes()
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

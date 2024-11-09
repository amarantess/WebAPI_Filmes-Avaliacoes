using AutoMapper;
using Filmes_Avaliacoes.Application.DTOs;
using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Application.Mappings;
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

		public async Task<Response<Filme>> CadastrarFilme(FilmeDto filmeDto)
		{
            Response<Filme> resposta = new Response<Filme>();

			var autoMapper = new MapperConfiguration(options =>
			{
				options.AddProfile(new AutoMapping());
			}).CreateMapper();

			var filme = autoMapper.Map<Filme>(filmeDto);

			_context.Add(filme);
			await _context.SaveChangesAsync();

			resposta.Dados = filme;
			resposta.Mensagem = "Filme cadastrado com sucesso!";
			return resposta;

		}

		public async Task<Response<Filme>> EditarFilme(FilmeEdicaoDto filmeEdicaoDto)
		{
			Response<Filme> resposta = new Response<Filme>();

			var filme = await _context.Filmes.FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == filmeEdicaoDto.Id);
			if (filme == null)
			{
				resposta.Mensagem = "Nenhum registro localizado";
				return resposta;
			}

			var autoMapper = new MapperConfiguration(options =>
			{
				options.AddProfile(new AutoMapping());
			}).CreateMapper();

			// Mapeia as mudanças do DTO para a instância existente
			autoMapper.Map(filmeEdicaoDto, filme);

			_context.Update(filme);
			await _context.SaveChangesAsync();

			resposta.Dados = filme;
			resposta.Mensagem = "Filme editado com sucesso.";
			return resposta;
		}

		public async Task<Response<List<Filme>>> ExcluirFilme(int idFilme)
		{
			Response<List<Filme>> resposta = new Response<List<Filme>>();

			var filme = await _context.Filmes.FirstOrDefaultAsync(filmeBanco => filmeBanco.Id == idFilme);
			if (filme == null)
			{
				resposta.Mensagem = "Nenhum registro localizado";
				return resposta;
			}

			_context.Remove(filme);
			await _context.SaveChangesAsync();

			resposta.Dados = await _context.Filmes.ToListAsync();
			resposta.Mensagem = "Filme excluido com sucesso.";
			return resposta;
		}

		public async Task<Response<List<Filme>>> ListarFilmes()
		{
			Response<List<Filme>> resposta = new Response<List<Filme>>();

			var filmes = await _context.Filmes.ToListAsync();

			resposta.Dados = filmes;
			resposta.Mensagem = "Todos os filmes foram encontrados";
			return resposta;

		}


	}
}

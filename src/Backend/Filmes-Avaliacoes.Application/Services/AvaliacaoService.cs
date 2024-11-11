﻿using AutoMapper;
using Filmes_Avaliacoes.Application.DTOs;
using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Application.Mappings;
using Filmes_Avaliacoes.Domain.Entities;
using Filmes_Avaliacoes.Infrastructure.DataAcess;
using Microsoft.EntityFrameworkCore;

namespace Filmes_Avaliacoes.Application.Services
{
	public class AvaliacaoService : IAvaliacaoInterface
	{
        private readonly AppDbContext _context;

        // Construtor
        public AvaliacaoService(AppDbContext context)
        {
            _context = context;
        }

		public async Task<Response<List<Avaliacao>>> CadastrarAvaliacao(AvaliacaoDto avaliacaoDto)
		{
			Response<List<Avaliacao>> resposta = new Response<List<Avaliacao>>();

			// Verificar se o filme existe antes de criar a avaliação
			var filme = await _context.Filmes.FindAsync(avaliacaoDto.FilmeId);
			if (filme == null)
			{
				resposta.Mensagem = "Registro não localizado";
				return resposta;
			}

			// Verificar se a nota está no intervalo correto
			if (avaliacaoDto.Nota < 1 || avaliacaoDto.Nota > 10)
			{
				resposta.Mensagem = "A nota deve estar entre 1 e 10.";
				return resposta;
			}

			// Mapeamento do DTO para a entidade Avaliacao
			var autoMapper = new MapperConfiguration(options =>
			{
				options.AddProfile(new AutoMapping());
			}).CreateMapper();

			var avaliacao = autoMapper.Map<Avaliacao>(avaliacaoDto);

			_context.Avaliacoes.Add(avaliacao);
			await _context.SaveChangesAsync();

			// Retorna apenas as avaliações do filme avaliado
			resposta.Dados = await _context.Avaliacoes
				.Include(a => a.Filme)
				.Where(a => a.FilmeId == avaliacaoDto.FilmeId) // Filtra pelo ID do filme
				.ToListAsync();

			resposta.Mensagem = "Avaliação criada com sucesso.";
			return resposta;
		}
	}
}
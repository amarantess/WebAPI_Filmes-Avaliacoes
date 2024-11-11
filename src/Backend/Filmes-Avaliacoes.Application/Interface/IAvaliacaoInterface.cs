using Filmes_Avaliacoes.Application.DTOs;
using Filmes_Avaliacoes.Domain.Entities;

namespace Filmes_Avaliacoes.Application.Interface
{
	public interface IAvaliacaoInterface
	{
		Task<Response<List<Avaliacao>>> CadastrarAvaliacao(AvaliacaoDto avaliacaoDto);
		Task<Response<List<Avaliacao>>> AvaliacaoFilme(int idFilme);
		Task<Response<Avaliacao>> EditarAvaliacao(AvaliacaoEdicaoDto avaliacaoEdicaoDto);
	}
}

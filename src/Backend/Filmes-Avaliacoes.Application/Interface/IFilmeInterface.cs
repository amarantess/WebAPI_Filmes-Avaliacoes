using Filmes_Avaliacoes.Domain.Entities;

namespace Filmes_Avaliacoes.Application.Interface
{
	public interface IFilmeInterface
	{
		Task<Response<List<Filme>>> ListarAutores();
		Task<Response<Filme>> BuscarFilmePorId(int idFilme);
	}
}

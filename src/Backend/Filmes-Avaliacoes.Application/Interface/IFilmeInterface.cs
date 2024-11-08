using Filmes_Avaliacoes.Domain.Entities;

namespace Filmes_Avaliacoes.Application.Interface
{
	public interface IFilmeInterface
	{
		Task<Response<List<Filme>>> ListarFilmes();
		Task<Response<Filme>> BuscarFilmePorId(int idFilme);
	}
}

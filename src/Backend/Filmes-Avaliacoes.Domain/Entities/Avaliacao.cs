using System.ComponentModel.DataAnnotations;

namespace Filmes_Avaliacoes.Domain.Entities
{
	public class Avaliacao
	{
		// Relação com o filme
		public Filme Filme { get; set; }
		public int Id { get; set; }

		[Range(1, 10)]
		public int Nota { get; set; }
		public string? Comentario { get; set; }
		public int FilmeId { get; set; }
	}
}

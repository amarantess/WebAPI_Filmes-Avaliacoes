﻿namespace Filmes_Avaliacoes.Domain.Entities
{
	public class Filme
	{
        public int Id { get; set; }
		public string Titulo { get; set; }
        public string Genero { get; set; }
        public DateTime DataLancamento { get; set; }
        public string Sinopse { get; set; }
    }
}

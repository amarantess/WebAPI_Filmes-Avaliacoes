﻿using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes_Avaliacoes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class FilmeController : ControllerBase
	{
		private readonly IFilmeInterface _filmeInterface;

		public FilmeController(IFilmeInterface filmeInterface)
        {
			_filmeInterface = filmeInterface;
		}


		[HttpGet("ListarFilmes")]
		public async Task<ActionResult<Response<List<Filme>>>> ListarAutor()
		{
			var filme = await _filmeInterface.ListarAutores();
			return Created(string.Empty ,filme);
		}
    }
}

using Filmes_Avaliacoes.Application.DTOs;
using Filmes_Avaliacoes.Application.Interface;
using Filmes_Avaliacoes.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Filmes_Avaliacoes.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AvaliacaoController : ControllerBase
	{
		private readonly IAvaliacaoInterface _avaliacaoInterface;

		public AvaliacaoController(IAvaliacaoInterface avaliacaoInterface)
		{
			_avaliacaoInterface = avaliacaoInterface;
		}

		[HttpPost("CadastrarAvaliacao")]
		public async Task<ActionResult<Response<List<Avaliacao>>>> CadastrarAvaliacao(AvaliacaoDto avaliacaoDto)
		{
			var avaliacao = await _avaliacaoInterface.CadastrarAvaliacao(avaliacaoDto);
			return Created(string.Empty, avaliacao);
		}


		[HttpGet("AvaliacaoFilme/{idFilme}")]
		public async Task<ActionResult<Response<List<Avaliacao>>>> AvaliacaoFilme(int idFilme)
		{
			var avaliacao = await _avaliacaoInterface.AvaliacaoFilme(idFilme);
			return Ok(avaliacao);
		}


		[HttpPut("EditarAvaliacao")]
		public async Task<ActionResult<Response<Avaliacao>>> EditarAvaliacao(AvaliacaoEdicaoDto avaliacaoEdicaoDto)
		{
			var avaliacao = await _avaliacaoInterface.EditarAvaliacao(avaliacaoEdicaoDto);
			return Ok(avaliacao);
		}


		[HttpDelete("ExcluirAvaliacao/{idAvaliacao}")]
		public async Task<ActionResult<Response<Avaliacao>>> ExcluirAvaliacao(int idAvaliacao)
		{
			var avaliacao = await _avaliacaoInterface.ExcluirAvaliacao(idAvaliacao);
			return Ok(avaliacao);
		}
	}
}

using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;

namespace Filmes_Avaliacoes.Application.Middlewares
{
	public class ExceptionMiddleware
	{
        private readonly RequestDelegate _next;

		// O construtor recebe um RequestDelegate, que representa o próximo passo no pipeline
		public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

		// Método InvokeAsync, chamado automaticamente pelo pipeline de requisições
		public async Task InvokeAsync(HttpContext context)
		{
			try
			{
				await _next(context); // Executa a próxima etapa da requisição
			}
			catch (Exception ex)
			{
				await HandleExceptionAsync(context, ex); // Trata a exceção se houver
			}
		}

		private Task HandleExceptionAsync(HttpContext context, Exception ex)
		{
			context.Response.ContentType = "application/json";
			context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

			var response = new
			{
				Status = false,
				Message = "Ocorreu um erro no processamento da requisição.",
				Error = ex.Message
			};

			// Serializa o objeto para JSON
			var jsonResponse = JsonSerializer.Serialize(response);

			return context.Response.WriteAsync(jsonResponse);
		}

	}
}

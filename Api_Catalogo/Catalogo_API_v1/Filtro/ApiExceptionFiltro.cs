using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalogo_API_v1.Filtro
{
    public class ApiExceptionFiltro:IExceptionFilter
    {
       private readonly ILogger _logger;

        public ApiExceptionFiltro(ILogger<ApiExceptionFiltro> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            _logger.LogError(context.Exception, "Ocorreu uma excecao nao tratada");
            context.Result = new ObjectResult("Ocorreu um erro ao tratar a sua solicitacao") { StatusCode = StatusCodes.Status500InternalServerError, };
        }
    }
}

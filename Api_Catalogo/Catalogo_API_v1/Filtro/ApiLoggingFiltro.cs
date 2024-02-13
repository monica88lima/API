using Microsoft.AspNetCore.Mvc.Filters;

namespace Catalogo_API_v1.Filtro
{
    public class ApiLoggingFiltro:IActionFilter
    {
        private readonly ILogger _logger;

        public ApiLoggingFiltro(ILogger<ApiLoggingFiltro> logger)
        {
            _logger = logger;
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            //executa antes
            _logger.LogInformation("#### Executando OnActionExecuted ####");
            _logger.LogInformation($"{DateTime.Now.ToShortTimeString()}");
            _logger.LogInformation($"ModelState : {context.ModelState.IsValid}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //execute depois
            _logger.LogInformation("#### Executando OnActionExecuting ####");
            _logger.LogInformation($"{DateTime.Now.ToLongDateString()}");
            _logger.LogInformation($"ModelState : {context.HttpContext.Response.StatusCode}");
        }
    }
}

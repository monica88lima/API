using System.Net;

using Entidades;
using Microsoft.AspNetCore.Diagnostics;

namespace Catalogo_API_v1.Middleware
{
    public static class ApiExceptionMiddlewareExtensions
    {

        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            //configura o tratamento de excecao
            app.UseExceptionHandler(appError =>
            //run informa o que fazer com uma excecao nao tratada
            appError.Run(async context =>
            {
                //informa qual statuscode colocar e o formato que se deve apresentar o erro json
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    //onde e escrito os detalhes
                    await context.Response.WriteAsync(new DetalheErros()
                    {
                        StatusCode = context.Response.StatusCode,
                        Mensagem = contextFeature.Error.Message,
                        Trace = contextFeature.Error.StackTrace

                    }.ToString());
                }
            }));
        }
    }
}

using ApiTarefas.Data;
using Dapper.Contrib.Extensions;
using static ApiTarefas.Data.TarefaContext;

namespace ApiTarefas.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem vindo a APi Tarefas - {DateTime.Now}");
            app.MapGet("/tarefas", async (GetConnection connectionGetter) =>
            {
                try
                {
                    using var con = await connectionGetter();
                    var tarefas = con.GetAll<Tarefa>().ToList();
                    if (tarefas is null) return Results.NotFound();
                    return Results.Ok(tarefas);

                }
                catch (Exception e)
                {

                    return Results.Problem(e.Message);
                }
                
            });
        }
    }
}

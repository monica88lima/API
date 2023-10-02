namespace ApiTarefas.Endpoints
{
    public static class TarefasEndpoints
    {
        public static void MapTarefasEndpoints(this WebApplication app)
        {
            app.MapGet("/", () => $"Bem vindo a APi Tarefas - {DateTime.Now}");
        }
    }
}

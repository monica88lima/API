using System.Data.SqlClient;
using static ApiTarefas.Data.TarefaContext;

namespace ApiTarefas.Extensions
{
    public static class ServiceCollectionsExtensions
    {
        //para registrar o serviço do Dapper

        public static WebApplicationBuilder addPersistence(this WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

            builder.Services.AddScoped<GetConnection>(sp =>
            async () =>
            {
                var connection = new SqlConnection(connectionString);
                await connection.OpenAsync();
                return connection;
            });
            return builder;
        }
    }
}

namespace Catalogo_API_v1.Log
{
    public class CustomLoggerConfig
    {
        //Define o nivel minimo de log a ser registrdo, como padrao
        public LogLevel LogLevel { get; set; } = LogLevel.Warning;

        //Define o ID do Evento do log
        public int EventId { get; set; } = 0;
    }
}

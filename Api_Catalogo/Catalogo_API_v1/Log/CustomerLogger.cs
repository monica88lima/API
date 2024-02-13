using System.Text;

namespace Catalogo_API_v1.Log
{
    public class CustomerLogger : ILogger
    {
        readonly string loggerName;
        readonly CustomLoggerConfig config;

        public CustomerLogger(CustomLoggerConfig config, string nome)
        {
            this.config = config;
            this.loggerName = nome;
        }

        //scopo para retorno da mensagem
        public IDisposable? BeginScope<TState>(TState state) where TState : notnull
        {
            return null;
        }
        //verifica se esta habilitado
        public bool IsEnabled(LogLevel logLevel)
        {
            return logLevel == config.LogLevel;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{logLevel.ToString()} : ");
            sb.Append($"{eventId}");
            sb.Append($"{formatter(state,exception)}");

            Escrever(sb);
        }

        private void Escrever(StringBuilder sb)
        {
            string dataAtual = DateTime.Now.ToShortDateString();
            string nomeArquivo = $"log-data{dataAtual.Replace('/', '-')}";
            string caminhoSaidaLog = @"C:\log\" + nomeArquivo + ".txt";

            using (StreamWriter streamWriter = new StreamWriter(caminhoSaidaLog, true)) 
            {
                try
                {
                    streamWriter.WriteLine(sb.ToString());
                    streamWriter.Close();
                }
                catch (Exception)
                {

                    throw;
                }
            
            }
        }
    }
}

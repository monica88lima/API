using System.Collections.Concurrent;

namespace Catalogo_API_v1.Log
{
    public class CustomLoggerProvider : ILoggerProvider
    {
        readonly CustomLoggerConfig loggerConfig;
        readonly ConcurrentDictionary<string, CustomerLogger> loggers = new ConcurrentDictionary<string, CustomerLogger>();

        public CustomLoggerProvider(CustomLoggerConfig loggerConfig)
        {
            this.loggerConfig = loggerConfig;
        }

        public ILogger CreateLogger(string categoryName)
        {
            return loggers.GetOrAdd(categoryName, name => new CustomerLogger(loggerConfig, name));
        }

        public void Dispose()
        {
            loggers.Clear();
        }
    }
}

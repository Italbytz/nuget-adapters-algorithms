using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Util
{
    public static class LoggingExtensions
    {
        private static ILogger _queueSearchLogger = NullLogger.Instance;

        public static void InitLoggers(ILoggerFactory loggerFactory)
        {
            _queueSearchLogger = loggerFactory.CreateLogger("QueueSearch");
        }

        public static void Log<TState, TAction>(
            this QueueSearch<TState, TAction> search, LogLevel logLevel,
            string message)
        {
            _queueSearchLogger.Log(logLevel, message);
        }
    }
}
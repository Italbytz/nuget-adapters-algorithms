using Italbytz.Adapters.Algorithms.Search.Framework.QSearch;
using Italbytz.Adapters.Algorithms.Search.Local;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;

namespace Italbytz.Adapters.Algorithms.Util
{
    public static class LoggingExtensions
    {
        private static ILogger _queueSearchLogger = NullLogger.Instance;
        private static ILogger _hillClimbingSearchLogger = NullLogger.Instance;

        private static ILogger _simulatedAnnealingSearchLogger =
            NullLogger.Instance;

        public static void InitLoggers(ILoggerFactory loggerFactory)
        {
            _queueSearchLogger = loggerFactory.CreateLogger("QueueSearch");
            _hillClimbingSearchLogger =
                loggerFactory.CreateLogger("HillClimbingSearch");
            _simulatedAnnealingSearchLogger =
                loggerFactory.CreateLogger("SimulatedAnnealingSearch");
        }

        public static void Log<TState, TAction>(
            this QueueSearch<TState, TAction> search, LogLevel logLevel,
            string message)
        {
            _queueSearchLogger.Log(logLevel, message);
        }

        public static void Log<TState, TAction>(
            this HillClimbingSearch<TState, TAction> search, LogLevel logLevel,
            string message)
        {
            _hillClimbingSearchLogger.Log(logLevel, message);
        }

        public static void Log<TState, TAction>(
            this SimulatedAnnealingSearch<TState, TAction> search,
            LogLevel logLevel, string message)
        {
            _simulatedAnnealingSearchLogger.Log(logLevel, message);
        }
    }
}
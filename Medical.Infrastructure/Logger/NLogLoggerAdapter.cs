using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Logger
{
 public partial class NLogLoggerAdapter:IApplicationLogger
    {
        private readonly ILogger _logger;

        public NLogLoggerAdapter(ILogger logger)
        {
            _logger = logger;
        }

        public void LogInformation(string message)
        {
            _logger.Info()
                .Message(message)
                .Write();

            Console.WriteLine(message);
        }

        public void LogInformation(Exception ex)
        {
            _logger.Info()
                  .Message(ex.Message)
                  .Exception(ex)
                  .Write();

            Console.WriteLine(ex);
        }

        public void LogInformation(Exception ex, IDictionary dictionaryOfProperties)
        {
            _logger.Info()
                   .Message(ex.Message)
                   .Exception(ex)
                   .Properties(dictionaryOfProperties)
                   .Write();
        }

        public void LogWarning(string message)
        {
            _logger.Warn()
                   .Message(message)
                   .Write();
        }

        public void LogWarning(Exception ex)
        {
            _logger.Warn()
                   .Message(ex.Message)
                   .Exception(ex)
                   .Write();
        }

        public void LogWarning(Exception ex, IDictionary dictionaryOfProperties)
        {
            _logger.Warn()
                   .Message(ex.Message)
                   .Exception(ex)
                   .Properties(dictionaryOfProperties)
                   .Write();
        }

        public void LogError(string message)
        {
            _logger.Error()
                   .Message(message)
                   .Write();
        }

        public void LogError(Exception ex)
        {
            _logger.Error()
                   .Message(ex.Message)
                   .Exception(ex)
                   .Write();
        }

        public void LogError(Exception ex, string loggerName, IDictionary dictionaryProperties)
        {
            _logger.Error()
                   .LoggerName(loggerName)
                   .Message(ex.Message)
                   .Exception(ex)
                   .Properties(dictionaryProperties)
                   .Write();
        }

        public void LogError(Exception ex, IDictionary dictionaryOfProperties)
        {
            _logger.Error()
                   .Message(ex.Message)
                   .Exception(ex)
                   .Properties(dictionaryOfProperties)
                   .Write();
        }
    }

    public partial class NLogLoggerAdapter : IApplicationLogger
    {
        private LogBuilder _logBuilder;

        public NLogLoggerAdapter Error()
        {
            _logBuilder = _logger.Error();
            return this;
        }

        public NLogLoggerAdapter Warn()
        {
            _logBuilder = _logger.Warn();
            return this;
        }

        public NLogLoggerAdapter Info()
        {
            _logBuilder = _logger.Info();
            return this;
        }

        public NLogLoggerAdapter Debug()
        {
            _logBuilder = _logger.Debug();
            return this;
        }

        public NLogLoggerAdapter Message(string message)
        {
            _logBuilder.Message(message);
            return this;
        }

        public NLogLoggerAdapter Message(string format, params object[] args)
        {
            _logBuilder.Message(format, args);
            return this;
        }

        public NLogLoggerAdapter Exception(Exception ex)
        {
            _logBuilder.Exception(ex);
            return this;
        }

        public NLogLoggerAdapter Properties(IDictionary dictionaryOfProperties)
        {
            _logBuilder.Properties(dictionaryOfProperties);
            return this;
        }

        public NLogLoggerAdapter Property(object name, object value)
        {
            _logBuilder.Property(name, value);
            return this;
        }

        public void Write()
        {
            _logBuilder.Write();
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Medical.Infrastructure.Logger.Contracts
{
 public interface IApplicationLogger
    {
        void LogInformation(string message);
        void LogInformation(Exception ex);
        void LogInformation(Exception ex, IDictionary properties);
        void LogWarning(string message);
        void LogWarning(Exception ex);
        void LogWarning(Exception ex, IDictionary properties);
        void LogError(string message);
        void LogError(Exception ex);
        void LogError(Exception ex, IDictionary properties);
        void LogError(Exception ex, string loggerName, IDictionary properties);

        NLogLoggerAdapter Error();
        NLogLoggerAdapter Warn();
        NLogLoggerAdapter Info();
        NLogLoggerAdapter Debug();
        NLogLoggerAdapter Message(string message);
        NLogLoggerAdapter Exception(Exception ex);
        NLogLoggerAdapter Properties(IDictionary dictionaryOfProperties);
        NLogLoggerAdapter Property(object name, object value);
        void Write();
    }
}

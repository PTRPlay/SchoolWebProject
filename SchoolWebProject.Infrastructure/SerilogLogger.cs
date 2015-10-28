using System;
using Serilog;

namespace SchoolWebProject.Infrastructure
{
    public class SerilogLogger : ILogger
    {
        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            Log.Warning(messageTemplate, propertyValues);
        }

        public void Info(string messageTemplate, params object[] propertyValues)
        {
            Log.Information(messageTemplate, propertyValues);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            Log.Error(messageTemplate, propertyValues);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            Log.Debug(messageTemplate, propertyValues);
        }

        public void Trace(string messageTemplate, params object[] propertyValues)
        {
            Log.Verbose(messageTemplate, propertyValues);
        }
    }
}

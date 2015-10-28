using System;
using Serilog;

namespace SchoolWebProject.Infrastructure
{
    public class SerilogLogger : ILogger
    {
        public SerilogLogger()
        {
            Log.Logger = new LoggerConfiguration().ReadFrom.AppSettings().CreateLogger();
        }

        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Warning(messageTemplate, propertyValues);
        }

        public void Info(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Information(messageTemplate, propertyValues);
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Error(messageTemplate, propertyValues);
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Debug(messageTemplate, propertyValues);
        }

        public void Trace(string messageTemplate, params object[] propertyValues)
        {
            Log.Logger.Verbose(messageTemplate, propertyValues);
        }
    }
}

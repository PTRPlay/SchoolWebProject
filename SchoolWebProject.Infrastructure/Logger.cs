using System;
using System.Text;

namespace SchoolWebProject.Infrastructure
{
    public class Logger : ILogger
    {
        public void Warning(string messageTemplate, params object[] propertyValues)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void Info(string messageTemplate, params object[] propertyValues)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void Error(string messageTemplate, params object[] propertyValues)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void Debug(string messageTemplate, params object[] propertyValues)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void Trace(string messageTemplate, params object[] propertyValues)
        {
            System.Diagnostics.Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }
    }
}

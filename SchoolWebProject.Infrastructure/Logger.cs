using System;
using System.Diagnostics;
using System.Text;

namespace SchoolWebProject.Infrastructure
{
    public class Logger : ILogger
    {
        public void WarningLog(string messageTemplate, params object[] propertyValues)
        {
            Debug.Write(string.Format(messageTemplate, propertyValues));
        }

        public void InfoLog(string messageTemplate, params object[] propertyValues)
        {
            Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void ErrorLog(string messageTemplate, params object[] propertyValues)
        {
            Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void DebugLog(string messageTemplate, params object[] propertyValues)
        {
            Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }

        public void TraceLog(string messageTemplate, params object[] propertyValues)
        {
            Debug.WriteLine(string.Format(messageTemplate, propertyValues));
        }
    }
}

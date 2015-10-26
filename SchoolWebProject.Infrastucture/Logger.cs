using System;
using System.Diagnostics;
using System.Text;

namespace SchoolWebProject.Infrastucture
{
    public class Logger : ILogger
    {
        public void WarningLog(string message)
        {
            Debug.Write(message);
        }

        public void InfoLog(string message)
        {
            Debug.WriteLine(message);
        }

        public void ErrorLog(string message)
        {
            Debug.WriteLine(message);
        }

        public void DebugLog(string message)
        {
            Debug.WriteLine(message);
        }

        public void TraceLog(string message)
        {
            Debug.WriteLine(message);
        }
    }
}

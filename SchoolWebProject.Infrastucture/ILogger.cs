using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Infrastucture
{
    private interface ILogger
    {
        void WarningLog(string message);

        void InfoLog(string message);

        void ErrorLog(string message);
        
        void DebugLog(string message);
        
        void TraceLog(string message);
    }
}

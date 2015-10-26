using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Infrastructure
{
    public interface ILogger
    {
        void WarningLog(string messageTemplate, params object[] propertyValues);

        void InfoLog(string messageTemplate, params object[] propertyValues);

        void ErrorLog(string messageTemplate, params object[] propertyValues);

        void DebugLog(string messageTemplate, params object[] propertyValues);

        void TraceLog(string messageTemplate, params object[] propertyValues);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Infrastructure
{
    public interface ILogger
    {
        void Warning(string messageTemplate, params object[] propertyValues);

        void Info(string messageTemplate, params object[] propertyValues);

        void Error(string messageTemplate, params object[] propertyValues);

        void Debug(string messageTemplate, params object[] propertyValues);

        void Trace(string messageTemplate, params object[] propertyValues);
    }
}

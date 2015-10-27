using System;
using SchoolWebProject.Infrastructure;

namespace SchoolWebProject.Services
{
    public class BaseService
    {
        private ILogger logger;

        public BaseService(ILogger logger)
        {
            this.logger = logger;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Interfaces;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Data.Infrastructure;

namespace SchoolWebProject.Services.Implementations
{
    public class UserService : BaseService, IUserService
    {
        private IUnitOfWork unitOfWork;

        public UserService(ILogger logger, IUnitOfWork unit)
            : base(logger)
        {
            this.unitOfWork = unit;
        }

        public User GetById(int id)
        {
            return this.unitOfWork.UserRepository.GetById(id);
        }
    }
}

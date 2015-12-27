using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services.Implementations
{
    public class RoomService:IRoomService
    {
        private IUnitOfWork unitOfWork;

        public RoomService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        
        public IEnumerable<string> GetAllRoom()
        {
            return unitOfWork.ClassRoomRepository.GetAll().Select(p=>p.Name);
        }
    }
}

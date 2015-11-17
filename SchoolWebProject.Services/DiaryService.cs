using System;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public class DiaryService : BaseService, IDiaryService
    {
        private IRepository<SchoolWebProject.Domain.Models.Pupil> pupilRepository;

        private IRepository<Group> groupRepository;
        private IRepository<Schedule> scheduleRepository;
        private IRepository<Subject> subjectRepository;

        private IUnitOfWork unitOfWork;

        public DiaryService(ILogger logger, IRepository<SchoolWebProject.Domain.Models.Pupil> pupilRepository, IRepository<Group> groupRepository, IRepository<Schedule> scheduleRepository, IRepository<Subject> subjectRepository, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.pupilRepository = pupilRepository;
            this.groupRepository = groupRepository;
            this.scheduleRepository = scheduleRepository;
            this.subjectRepository = subjectRepository;
            this.unitOfWork = unitOfWork;
        }

        //public Diary GetDiaryByUserId(int IdUser, DateTime data)
        public IEnumerable<Diary> GetDiaryByUserId(int IdUser)
        {
            var pupils = pupilRepository.GetAll();
            var schedule = scheduleRepository.GetAll();
            var temp = (from p in pupils
                       join s in schedule
                       on p.GroupId equals s.GroupId
                       // join 
                       where p.Id == IdUser
                       orderby s.DayOfTheWeek ascending
                       select new Diary { IdPupil = p.Id, DayOfTheWeek = s.DayOfTheWeek, OrderNumber = s.OrderNumber, SubjectId = s.SubjectId, SubjectName = subjectRepository.GetById(s.SubjectId).Name }); 

            return temp;
          }



    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using sModels = SchoolWebProject.Services.Models;
using SchoolWebProject.Services.Interfaces;

namespace SchoolWebProject.Services
{
    public class PupilService : BaseService, IPupilService
    {
        private IUnitOfWork unitOfWork;
        private IAccountService accountService;
        private IGroupService groupService;

        public PupilService(ILogger logger, IUnitOfWork unitOfWork, IAccountService accountService, IGroupService groupService)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
            this.accountService = accountService;
            this.groupService = groupService;
        }

        public IEnumerable<sModels.ViewPupil> GetAllPupils()
        {
            var pupils = unitOfWork.PupilRepository.GetAll().OrderBy(p => p.LastName);
            var viewModel = AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<sModels.ViewPupil>>(pupils);
            logger.Info("Retrieving all pupils");
            return viewModel;
        }

        public IEnumerable<sModels.ViewPupil> GetPage(int pageNumb, int amount, string sorting, string filtering, out int pageCount)
        {
            IEnumerable<Pupil> pupils = null;

            if (filtering != null)
            {
                pupils = unitOfWork.PupilRepository.GetMany(p => p.LastName.ToLower().StartsWith(filtering.ToLower()));
                pageCount = pupils.Count();
                pupils = pupils.AsQueryable().OrderBy(sorting).Skip((pageNumb - 1) * amount).Take(amount);
                return AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<sModels.ViewPupil>>(pupils); 
            }

            pupils = unitOfWork.PupilRepository.GetAll().OrderBy(sorting);
            pageCount = pupils.Count();
            pupils = pupils.Skip((pageNumb - 1) * amount).Take(amount);
            logger.Info("Retrieving page with pupils from a server. Page # {0}, amount - {1}", pageNumb, amount);
            return AutoMapper.Mapper.Map<IEnumerable<Pupil>, IEnumerable<sModels.ViewPupil>>(pupils); ;
        }

        public sModels.ViewPupil GetProfileById(int id)
        {
            logger.Info("Retrieving pupil with id {0}", id);
            if(id < 0)
            {
                throw new ArgumentException("id should be greater than zero!");
            }
            var pupil = this.unitOfWork.PupilRepository.GetById(id);
            var viewModel = AutoMapper.Mapper.Map<Pupil, sModels.ViewPupil>(pupil);

            return viewModel;
        }

        public sModels.ViewPupil Get(Expression<Func<Pupil, bool>> expression)
        {
            var pupil = unitOfWork.PupilRepository.Get(expression);
            var viewModel = AutoMapper.Mapper.Map<Pupil, sModels.ViewPupil>(pupil);
            return viewModel;
        }

        public void UpdateProfile(sModels.ViewPupil value)
        {
            AutoMapper.Mapper.CreateMap<sModels.ViewPupil, Pupil>();
            var pupil = AutoMapper.Mapper.Map<sModels.ViewPupil, Pupil>(value);
           
            if (value.GroupLetter != null && value.GroupNumber != null)
            {
                Group group = groupService.GetAllGroups().Where(g => g.NameNumber.ToString() == value.GroupNumber).First(g => g.NameLetter == value.GroupLetter);
                pupil.GroupId = group.Id;
            }

            unitOfWork.PupilRepository.Update(pupil);
            unitOfWork.SaveChanges();
            logger.Info("Edited pupil {0} {1}", value.FirstName, value.LastName);

        }

        public void AddPupil(sModels.ViewPupil value)
        {
            AutoMapper.Mapper.CreateMap<sModels.ViewPupil, Pupil>();
            Pupil pupil = AutoMapper.Mapper.Map<sModels.ViewPupil, Pupil>(value);
            pupil.RoleId = 3;
            if (pupil.Email != null)
            {
                pupil.LogInData = this.accountService.GenerateUserLoginData(pupil);
            }

            //assigning group to pupil
            if (value.GroupLetter != null && value.GroupNumber != null)
            {
                Group group = groupService.Get(g => g.NameNumber.ToString() == value.GroupNumber && g.NameLetter == value.GroupLetter);
                pupil.GroupId = group.Id;
            }
            unitOfWork.PupilRepository.Add(pupil);
            unitOfWork.SaveChanges();
            logger.Info("Added pupil {0} {1}", value.FirstName, value.LastName);
        }

        public void RemovePupil(int id)
        {
            Pupil pupil = this.unitOfWork.PupilRepository.GetById(id);
            //removing pupil's login data
           if (pupil!=null)
           {
               LogInData loginData = pupil.LogInData;
                if (loginData != null)
                {
                    unitOfWork.LogInDataRepository.Delete(loginData);
                }
           }
           
           unitOfWork.PupilRepository.Delete(pupil);
           unitOfWork.SaveChanges();
           logger.Info("Deleted pupil with id {0}", id);
        }
    }
}

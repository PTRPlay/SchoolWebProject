﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject;

namespace SchoolWebProject.Services
{
    public class MarkService : BaseService, IMarkService
    {
        private ILogger tmpLogger;
        private DbFactory dbFactory;
        private GenericRepository<Mark> repository;
        private UnitOfWork unitOfWork;

        public MarkService(ILogger logger)
            : base(logger)
        {
            this.tmpLogger = logger;
            this.dbFactory = new DbFactory();
            this.repository = new GenericRepository<Mark>(this.dbFactory);
            this.unitOfWork = new UnitOfWork(this.dbFactory);
        }

        public IEnumerable<Mark> GetAllMarks()
        {
            return repository.GetAll();
        }

        public Mark GetMarkById(int id)
        {
           return repository.GetById(id);
        }

        public void UpdateMark(Mark mark)
        {
            repository.Update(mark);
        }

        public void AddMark(Mark mark)
        {
            repository.Add(mark);
            unitOfWork.SaveChanges();
        }

        public void RemoveMark(Mark mark)
        {
            repository.Delete(mark);
        }

        public void SaveMark()
        {
            unitOfWork.SaveChanges();
        }
    }
}
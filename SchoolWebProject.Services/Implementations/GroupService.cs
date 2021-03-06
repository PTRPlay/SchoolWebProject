﻿using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Infrastructure;
using SchoolWebProject.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolWebProject.Services.Implementations
{
    public class GroupService : BaseService, IGroupService
    {
        private IUnitOfWork unitOfWork;

        public GroupService(ILogger logger, IUnitOfWork unitOfWork)
            : base(logger)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Group> GetAllGroups()
        {
            return this.unitOfWork.GroupRepository.GetAll().ToList();
        }

        public Group GetGroupById(int id)
        {
            return this.unitOfWork.GroupRepository.GetById(id);
        }

        public void UpdateGroup(Group group)
        {
            var copies = this.unitOfWork.GroupRepository.GetMany(
                g => ((g.NameNumber == group.NameNumber) && (g.NameLetter == group.NameLetter)));

            if (copies.ToList().Count == 0)
            {
                this.unitOfWork.GroupRepository.Update(group);
                this.unitOfWork.SaveChanges();
            }
        }

        public void AddGroup(Group group)
        {
            var copies = this.unitOfWork.GroupRepository.GetMany(
                g => ((g.NameNumber == group.NameNumber) && (g.NameLetter == group.NameLetter)));

            if (copies.ToList().Count == 0)
            {
                this.unitOfWork.GroupRepository.Add(group);
                this.unitOfWork.SaveChanges();
            }
        }

        public void RemoveGroup(int id)
        {
            Group group = this.unitOfWork.GroupRepository.GetById(id);
            group.Pupils.RemoveAll(p => p.GroupId == group.Id);
            group.Schedules.RemoveAll(p => p.GroupId == group.Id);
            group.Teacher.RemoveAll(p => p.GroupId == group.Id);
            this.unitOfWork.SaveChanges();

            this.unitOfWork.GroupRepository.Delete(group);
            this.unitOfWork.SaveChanges();
        }

        public void SaveChanges()
        {
            this.unitOfWork.SaveChanges();
        }

        public Group Get(System.Linq.Expressions.Expression<Func<Group, bool>> expression)
        {
            return unitOfWork.GroupRepository.Get(expression);
        }
    }
}

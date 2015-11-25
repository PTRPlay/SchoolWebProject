using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Services
{
    public interface ISubjectService
    {
        IEnumerable<Subject> GetAllSubjects();

        Subject GetSubjectById(int id);

        void UpdateSubject(Subject subject);

        void AddSubject(Subject subject);

        void RemoveSubject(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Data.Infrastructure;
using SchoolWebProject.Domain.Models;
using SchoolWebProject.Services.Models;

namespace SchoolWebProject.Services
{
    public interface IDiaryService
    {
        IEnumerable<Diary> GetDiaryByUserId(int id, string date);
    }
}

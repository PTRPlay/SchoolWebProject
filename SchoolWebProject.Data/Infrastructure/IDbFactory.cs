﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolWebProject.Domain.Models;

namespace SchoolWebProject.Data.Infrastructure
{
    public interface IDbFactory : IDisposable
    {
        SchoolContext Init();
    }
}

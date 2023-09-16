﻿using SMS.Entity.Domain;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.TeacherRepository
{
    public interface ITeacherRepository : IGenericRepository<Teacher>
    {
    }
}

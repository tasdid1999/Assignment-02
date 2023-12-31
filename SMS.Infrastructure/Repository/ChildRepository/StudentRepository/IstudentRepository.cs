﻿using SMS.ClientEntity.Response.Student;
using SMS.Entity.Domain;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
       Task<bool> Active(int id);

       Task<bool> InActive(int id);
    }
}

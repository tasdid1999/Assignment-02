﻿using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.GenericRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;
        
        public UnitOfWork(Context dbContext ,IStudentRepository _studentRepository)
        {
            _dbContext = dbContext;
            studentRepository = _studentRepository;
        }

       
        public IStudentRepository studentRepository {  get; private set; }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}

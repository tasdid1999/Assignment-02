using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly Context _dbContext;

        public StudentRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Task Hello()
        {
            throw new NotImplementedException();
        }
    }



}

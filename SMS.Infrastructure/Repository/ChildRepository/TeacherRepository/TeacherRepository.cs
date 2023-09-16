using Microsoft.Extensions.Configuration;
using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.TeacherRepository
{
    public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
    {
        private readonly Context _dbContext;

        public TeacherRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
  
        }

        public async override Task<bool> DeleteAsync(int id)
        {
            var teacher = await base.GetById(id, "teachers");

            if (teacher is not null)
            {
                teacher.StatusId = 2;
                return true;
            }

            return false;
        }
        public async override Task<bool> UpdateAsync(Teacher teacherRequest)
        {
            var teacher = await base.GetById(teacherRequest.Id, "teachers");

            if (teacher is not null)
            {
                teacher.Email = teacherRequest.Email;
                teacher.FirstName = teacherRequest.FirstName;
                teacher.LastName = teacherRequest.LastName;
                teacher.PhoneNumber = teacherRequest.PhoneNumber;
                teacher.Designation = teacherRequest.Designation;
                teacher.UpdatedAt = DateTime.Now;
                teacher.UpdatedBy = 1;
                return true;

            }

            return false;


        }
    }
}

using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Migrations;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.TeacherCourseRepository
{
    public class TeacherCourseRepository : GenericRepository<TeacherCourse>, ITeacherCourseRepository
    {
        private readonly Context _dbContext;

        public TeacherCourseRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<bool> DeleteAsync(int id)
        {
            var teacherCourse = await base.GetById(id, "teacherCourses");

            if (teacherCourse is not null)
            {
                teacherCourse.StatusId = 2;
                return true;
            }

            return false;
        }

        public async override Task<bool> UpdateAsync(TeacherCourse teacherCourseRequest)
        {
            var existingTeacherCourse = await base.GetById(teacherCourseRequest.Id, "teacherCourses");

            if (existingTeacherCourse is not null)
            {
               

                return true;
            }

            return false;
        }
    }
}

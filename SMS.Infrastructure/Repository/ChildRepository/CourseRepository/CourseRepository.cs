using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.ChildRepository.TeacherRepository;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.CourseRepository
{
    public class CourseRepository : GenericRepository<Course>, ICourseRepository
    {
        private readonly Context _dbContext;

        public CourseRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async override Task<bool> DeleteAsync(int id)
        {
            var course = await base.GetById(id, "courses");

            if (course is not null)course.UpdatedAt = DateTime.Now;
                course.UpdatedBy = 1;
            {
                course.StatusId = 2;
                return true;
            }

            return false;
        }

        public async override Task<bool> UpdateAsync(Course courseRequest)
        {
            var course = await base.GetById(courseRequest.Id, "courses");

            if (course is not null)
            {
                course.CourseCode = courseRequest.CourseCode;
                course.CourseName = courseRequest.CourseName;
                
                return true;
            }

            return false;
        }
    }
}

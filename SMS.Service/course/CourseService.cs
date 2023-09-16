using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.course
{
    public class CourseService : ICourseService
    {
        private readonly IUnitOfWork _unitOfWork;

        public CourseService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<bool> AddCourseAsync(Course course)
        {
            course.StatusId = 1;
            course.CreatedAt = DateTime.Now;
            course.CreatedBy = 1;

            await _unitOfWork.courseRepository.InsertAsync(course);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteCourseAsync(int id)
        {
            await _unitOfWork.courseRepository.DeleteAsync(id);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync(int page, int pageSize)
        {
            return await _unitOfWork.courseRepository.GetAllAsync(page, pageSize, "courses");
        }

        public async Task<Course?> GetCourseByIdAsync(int id)
        {
            return await _unitOfWork.courseRepository.GetById(id, "courses");
        }

        public async Task<bool> UpdateCourseAsync(Course course)
        {
            await _unitOfWork.courseRepository.UpdateAsync(course);

            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

using Microsoft.Extensions.Configuration;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.teacherCourse
{
    public class TeacherCourseService : ITeacherCourseService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public TeacherCourseService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<bool> AddTeacherCourseAsync(TeacherCourse teacherCourse)
        {
            teacherCourse.StatusId = 1;
            teacherCourse.CreatedAt = DateTime.Now;
            teacherCourse.CreatedBy = 1;

            await _unitOfWork.teacherCourseRepository.InsertAsync(teacherCourse);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteTeacherCourseAsync(int id)
        {
            await _unitOfWork.teacherCourseRepository.DeleteAsync(id);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<TeacherCourse>> GetAllTeacherCoursesAsync(int page, int pageSize)
        {
            return await _unitOfWork.teacherCourseRepository.GetAllAsync(page, pageSize, "teacherCourses");
        }

        public async Task<TeacherCourse?> GetTeacherCourseByIdAsync(int id)
        {
            return await _unitOfWork.teacherCourseRepository.GetById(id, "teacherCourses");
        }

        public async Task<bool> UpdateTeacherCourseAsync(TeacherCourse teacherCourse)
        {
            await _unitOfWork.teacherCourseRepository.UpdateAsync(teacherCourse);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMS.Entity.Domain;
namespace SMS.Service.teacherCourse
{
    public interface ITeacherCourseService
    {
        Task<IEnumerable<TeacherCourse>> GetAllTeacherCoursesAsync(int page, int pageSize);

        Task<TeacherCourse?> GetTeacherCourseByIdAsync(int id);

        Task<bool> AddTeacherCourseAsync(TeacherCourse teacherCourse);

        Task<bool> UpdateTeacherCourseAsync(TeacherCourse teacherCourse);

        Task<bool> DeleteTeacherCourseAsync(int id);
    }
}

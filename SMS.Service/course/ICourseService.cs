using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.course
{
    public interface ICourseService
    {
        Task<IEnumerable<Course>> GetAllCoursesAsync(int page, int pageSize);

        Task<Course?> GetCourseByIdAsync(int id);
        Task<bool> AddCourseAsync(Course course);

        Task<bool> UpdateCourseAsync(Course course);

        Task<bool> DeleteCourseAsync(int id);
    }
}

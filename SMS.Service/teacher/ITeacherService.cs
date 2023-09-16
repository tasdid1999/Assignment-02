using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.teacher
{
    public interface ITeacherService
    {
        Task<IEnumerable<Teacher>> GetAllTeacherAsync(int page, int pageSize);

        Task<Teacher?> GetTeacherByIdAsync(int id);
        Task<bool> AddTeacherAsync(Teacher teacher);

        Task<bool> UpdateTeacherAsync(Teacher teacher);

        Task<bool> DeleteTeacherAsync(int id);
    }
}

using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.student
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetAllStudentAsync(int page , int pageSize);

        Task<Student?> GetStudentByIdAsync(int id);
        Task<bool> AddStudentAsync(Student student);

        Task<bool> UpdateStudentAsync(Student student);

        Task<bool> DeleteStudentAsync(int id);

        Task<bool> ActiveAsync(int id);

        Task<bool> InActiveAsync(int id);
    }
}

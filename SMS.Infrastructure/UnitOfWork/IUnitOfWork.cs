using SMS.Infrastructure.Repository.ChildRepository.CourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherCourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IStudentRepository studentRepository { get; }
        ITeacherRepository teacherRepository { get; }

        ICourseRepository courseRepository { get; }

        ITeacherCourseRepository teacherCourseRepository { get; }
        Task<bool> SaveChangesAsync();
    }
}

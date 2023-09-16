using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.ChildRepository.CourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherCourseRepository;
using SMS.Infrastructure.Repository.ChildRepository.TeacherRepository;
using SMS.Infrastructure.Repository.GenericRepository;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Context _dbContext;

        public UnitOfWork(Context dbContext, IStudentRepository _studentRepository,
                                                ITeacherRepository _teacherRepository,
                                                ICourseRepository _courseRepository,
                                                ITeacherCourseRepository _teacherCourseRepository)
        {
            _dbContext = dbContext;
            studentRepository = _studentRepository;
            teacherRepository = _teacherRepository;
            courseRepository = _courseRepository;
            teacherCourseRepository = _teacherCourseRepository;
        }


        public IStudentRepository studentRepository {  get; private set; }
        public ITeacherRepository teacherRepository { get; private set; }

        public ICourseRepository courseRepository { get; private set; }

        public ITeacherCourseRepository teacherCourseRepository { get; private set; }

        public async Task<bool> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync() > 0;
        }
    }
}

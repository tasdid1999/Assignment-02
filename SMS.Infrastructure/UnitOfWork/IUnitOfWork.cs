using SMS.Infrastructure.Repository.ChildRepository.StudentRepository;
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

        Task<bool> SaveChangesAsync();
    }
}

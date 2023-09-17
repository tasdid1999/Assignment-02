using Microsoft.Extensions.Configuration;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.student
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;
        

        public StudentService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<bool> AddStudentAsync(Student student)
        {
            student.StatusId = 1;
            student.CreatedAt = DateTime.Now;
            student.CreatedBy = 1;

            await _unitOfWork.studentRepository.InsertAsync(student);

            return await _unitOfWork.SaveChangesAsync();

        }

        public async Task<IEnumerable<Student>> GetAllStudentAsync(int page, int pageSize)
        {
           var listOfStudent = await _unitOfWork.studentRepository.GetAllAsync(page, pageSize,"students");

           return listOfStudent;
        }

        public async Task<Student?> GetStudentByIdAsync(int id)
        {
           return await _unitOfWork.studentRepository.GetById(id, "students");

        }

        public async Task<bool> UpdateStudentAsync(Student student)
        {

                await _unitOfWork.studentRepository.UpdateAsync(student);

                return await _unitOfWork.SaveChangesAsync();
          
        }
        public async Task<bool> DeleteStudentAsync(int id)
        {
            await _unitOfWork.studentRepository.DeleteAsync(id);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> ActiveAsync(int id)
        {
            var isSucces = await _unitOfWork.studentRepository.Active(id);

            if (isSucces)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;

        }

        public async Task<bool> InActiveAsync(int id)
        {
           var isSucces =  await _unitOfWork.studentRepository.InActive(id);

            if (isSucces)
            {
                await _unitOfWork.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}

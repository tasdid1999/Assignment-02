using Microsoft.Extensions.Configuration;
using SMS.Entity.Domain;
using SMS.Infrastructure.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Service.teacher
{
    public class TeacherService : ITeacherService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;


        public TeacherService(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        public async Task<bool> AddTeacherAsync(Teacher teacher)
        {
            teacher.StatusId = 1;
            teacher.CreatedAt = DateTime.Now;
            teacher.CreatedBy = 1;

            await _unitOfWork.teacherRepository.InsertAsync(teacher);

            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> DeleteTeacherAsync(int id)
        {
           await _unitOfWork.teacherRepository.DeleteAsync(id);
            return await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<Teacher>> GetAllTeacherAsync(int page, int pageSize)
        {
           return await _unitOfWork.teacherRepository.GetAllAsync(page, pageSize,"teachers");

        }

        public async Task<Teacher?> GetTeacherByIdAsync(int id)
        {
            return await _unitOfWork.teacherRepository.GetById(id,"teachers");
        }

        public async Task<bool> UpdateTeacherAsync(Teacher teacher)
        {
           await _unitOfWork.teacherRepository.UpdateAsync(teacher);
            return await _unitOfWork.SaveChangesAsync();
        }
    }
}

using Azure;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SMS.ClientEntity.Response.Student;
using SMS.Entity.Domain;
using SMS.Infrastructure.Data;
using SMS.Infrastructure.Repository.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Repository.ChildRepository.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly Context _dbContext;
       

        public StudentRepository(Context dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
           
        }

        public async override Task<bool> DeleteAsync(int id)
       {
            var student = await base.GetById(id,"students");

            if (student is not null)
            {
                student.StatusId = 2;
                return true;
            }

            return false;
       }
       

        public async override Task<bool> UpdateAsync(Student studentRequest)
        {
            var student = await base.GetById(studentRequest.Id, "students");

            if (student is not null)
            {
                student.FirstName = studentRequest.FirstName;
                student.LastName = studentRequest.LastName;
                student.FatherName = studentRequest.FatherName;
                student.MotherName = studentRequest.MotherName;
                student.GenderId = studentRequest.GenderId;
                student.DateOfBirth = studentRequest.DateOfBirth;
                student.Address = studentRequest.Address;
                student.UpdatedAt = DateTime.Now;
                student.UpdatedBy = 1;

                return true;

            }

            return false;


        }
        public async Task<bool> Active(int id)
        {
            var student = await _context.students.Where(x =>  x.Id == id).FirstOrDefaultAsync();

            if(student is not null)
            {
                if(student.StatusId == 2 || student.StatusId == 1)
                {
                    return false;
                }

                student.StatusId= 1;
                return true;
            }

            return false;
        }
        public async Task<bool> InActive(int id)
        {
            var student = await _context.students.Where(x => x.Id == id).FirstOrDefaultAsync();

            if (student is not null)
            {
                if (student.StatusId == 2 || student.StatusId == 0)
                {
                    return false;
                }

                student.StatusId = 0;
                return true;
            }

            return false;
        }
    }



}

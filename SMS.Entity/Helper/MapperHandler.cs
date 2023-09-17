using AutoMapper;
using SMS.ClientEntity.Request.Course;
using SMS.ClientEntity.Request.Student;
using SMS.ClientEntity.Request.Teacher;
using SMS.ClientEntity.Request.teacherCourse;
using SMS.ClientEntity.Response.Course;
using SMS.ClientEntity.Response.Student;
using SMS.ClientEntity.Response.Teacher;
using SMS.ClientEntity.Response.teacherCourse;
using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SMS.Entity.Helper
{
    public class MapperHandler : Profile
    {
        public MapperHandler()
        {
            CreateMap<StudentRequest, Student>();
            CreateMap<Student, StudentResponse>();
            CreateMap<TeacherRequest, Teacher>();
            CreateMap<Teacher, TeacherResponse>();
            CreateMap<CourseRequest,Course>();
            CreateMap<Course, CourseResponse>();
            CreateMap<TeacherCourseRequest, TeacherCourse>();
            CreateMap<TeacherCourse, TeacherCourseResponse>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class Course : BaseEntity
    {
        [Required , MinLength(3) , MaxLength(10)]
        public string CourseCode { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string CourseName { get; set; }

        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}

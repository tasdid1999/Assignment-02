using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class Teacher : BaseEntity
    {

        [Required,MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }

        [Required,MinLength(3), MaxLength(100)]
        public string Designation {  get; set; }

        [Required,EmailAddress]
        public string Email { get; set; }

        [Required,MinLength(11), MaxLength(11)]
        public string PhoneNumber { get; set; }

        public List<TeacherCourse> TeacherCourses { get; set; }
    }
}

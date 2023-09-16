using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ClientEntity.Request.Course
{
    public class CourseRequest
    {

        public int Id { get; set; }
        public string CourseCode { get; set; }

        public string CourseName { get; set; }

    }
}

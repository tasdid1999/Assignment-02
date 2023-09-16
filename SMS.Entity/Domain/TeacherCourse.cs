using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class TeacherCourse : BaseEntity
    {
        public int TeacherId {  get; set; }
        
        public Teacher Teacher { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}

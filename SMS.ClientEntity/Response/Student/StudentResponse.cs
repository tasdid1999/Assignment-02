using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.ClientEntity.Response.Student
{
    public class StudentResponse
    {
        public int Id { get; set; }
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public int GenderId { get; set; }

        public string FatherName { get; set; }

        public string MotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Address { get; set; }
    }
}

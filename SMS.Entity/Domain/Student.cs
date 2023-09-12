using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class Student : BaseEntity
    {

        [Required, MinLength(3), MaxLength(100)]
        public string FirstName { get; set; }

        [Required, MinLength(3), MaxLength(100)]
        public string LastName { get; set; }

        public int GenderId { get; set; }

        public Gender Gender { get; set; }

        [Required, MaxLength(100)]
        public string FatherName { get; set; }

        [Required, MaxLength(100)]
        public string MotherName { get; set; }

        public DateTime DateOfBirth { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }
    }
}

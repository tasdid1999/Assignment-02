using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public int CreatedBy { get; set; }
       
        public int? UpdatedBy { get; set;}

        [Required]
        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set;}

        [Required]
        public int StatusId { get; set; }
    }
}

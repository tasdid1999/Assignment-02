using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Entity.Domain
{
    public class Gender : BaseEntity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}

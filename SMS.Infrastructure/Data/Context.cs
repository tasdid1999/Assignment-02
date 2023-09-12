using Microsoft.EntityFrameworkCore;
using SMS.Entity.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMS.Infrastructure.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }


       public DbSet<Student> students { get; set; }

       public DbSet<Gender> genders { get; set; }

       public DbSet<Teacher> teachers { get; set; }    
       
    }
}

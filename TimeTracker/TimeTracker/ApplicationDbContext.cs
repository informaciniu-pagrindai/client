using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class ApplicationDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<AspNetUsers> Users { get; set; }
        public DbSet<ProjectMembers> ProjectMembers { get; set; }
    }
}

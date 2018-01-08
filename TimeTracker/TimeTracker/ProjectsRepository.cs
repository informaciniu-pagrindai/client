using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class ProjectsRepository
    {
        private readonly ApplicationDbContext ctx;

        public ProjectsRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<Project> GetAll()
        {
            return ctx.Projects.ToList();
        }
    }
}

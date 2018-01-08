using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class ProjectActionsRepository
    {

        private readonly ApplicationDbContext ctx;

        public ProjectActionsRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<ProjectActions> GetAll()
        {
            return ctx.ProjectActions.ToList();
        }

    }
}

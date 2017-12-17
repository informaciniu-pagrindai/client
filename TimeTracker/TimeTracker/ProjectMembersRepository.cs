using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class ProjectMembersRepository
    {

        private readonly ApplicationDbContext ctx;

        public ProjectMembersRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<ProjectMembers> GetAll()
        {
            return ctx.ProjectMembers.ToList();
        }

    }
}

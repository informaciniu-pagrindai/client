using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class RegisteredActionsRepository
    {

        private readonly ApplicationDbContext ctx;

        public RegisteredActionsRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<RegisteredActions> GetAll()
        {
            return ctx.RegisteredActions.ToList();
        }

    }
}

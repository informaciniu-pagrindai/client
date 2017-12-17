using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeTracker
{
    class AspNetUsersRepository
    {

        private readonly ApplicationDbContext ctx;

        public AspNetUsersRepository(ApplicationDbContext ctx)
        {
            this.ctx = ctx;
        }

        public List<AspNetUsers> GetAll()
        {
            return ctx.Users.ToList();
        }

    }
}

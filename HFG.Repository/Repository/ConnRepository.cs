using HFG.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    public class ConnRepository : EfRepository<conn>
    {
        public ConnRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}

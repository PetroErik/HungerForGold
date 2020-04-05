using HFG.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    public class DrillRepository : EfRepository<drill>
    {
        public DrillRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}

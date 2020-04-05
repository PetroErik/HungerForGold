using HFG.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository.Repository
{
    public class BrickRepository : EfRepository<brick>, IBrickRepository
    {
        public BrickRepository(DbContext ctx) : base(ctx)
        {
        }

        public void ChangeLocation(brick brick, int x, int y)
        {
            brick.brick_x = x;
            brick.brick_y = y;
            this.Ctx.SaveChanges();
        }
    }
}

using HFG.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository.Repository
{
    /// <summary>
    /// Brick repository .
    /// </summary>
    public class BrickRepository : EfRepository<brick>, IBrickRepository
    {
        /// <summary>
        /// constructor for Brick repository .
        /// </summary>
        /// <param name="ctx">Database context .</param>
        public BrickRepository(DbContext ctx) : base(ctx)
        {
        }

        /// <summary>
        /// method for changing the location of Brick .
        /// </summary>
        /// <param name="brick">selected brick .</param>
        /// <param name="x">x coordinate .</param>
        /// <param name="y">y coordinate .</param>
        public void ChangeLocation(brick brick, int x, int y)
        {
            brick.brick_x = x;
            brick.brick_y = y;
            this.Ctx.SaveChanges();
        }
    }
}

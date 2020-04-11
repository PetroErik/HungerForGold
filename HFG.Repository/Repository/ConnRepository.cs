using HFG.Database;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    /// <summary>
    /// connection repository .
    /// </summary>
    public class ConnRepository : EfRepository<conn>
    {
        /// <summary>
        /// Constructor for Conn repository .
        /// </summary>
        /// <param name="ctx">Database context .</param>
        public ConnRepository(DbContext ctx) : base(ctx)
        {
        }
    }
}

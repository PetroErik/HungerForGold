using HFG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    /// <summary>
    /// Interface for Brick repository .
    /// </summary>
   public interface IBrickRepository :IRepository<brick>
    {
        /// <summary>
        /// method for changing the location of Brick .
        /// </summary>
        /// <param name="brick">selected brick .</param>
        /// <param name="x">x coordinate .</param>
        /// <param name="y">y coordinate .</param>
        void ChangeLocation(brick brick, int x, int y);
    }
}

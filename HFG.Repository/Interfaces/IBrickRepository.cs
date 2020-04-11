using HFG.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
   public interface IBrickRepository :IRepository<brick>
    {
        void ChangeLocation(brick brick, int x, int y);
    }
}

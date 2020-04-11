using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display
{
    public class SiloHouse : Character
    {
        public SiloHouse(double x, double y)
        {
            this.Location = new double[2] { x, y };
        }
    }
}

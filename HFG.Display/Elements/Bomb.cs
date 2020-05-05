using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display.Elements
{
    public class Bomb : Character
    {
        public Bomb(double x, double y)
        {
            this.Location = new double[] { x, y };
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Display.Elements
{
    public class Enemy : Character
    {
        private static Random R = new Random();

        public int dx;

        public Enemy(double x, double y)
        {
            this.Location = new double[] { x, y };
            if (R.Next(0, 2) == 0)
            {
                dx = -1;
            }
            else dx = 1;
        }
    }
}

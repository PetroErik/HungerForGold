using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace HFG.Display
{
    public class Mineral : Character
    {
        public MineralsType Type { get; set; }

        public Mineral(double x, double y, MineralsType type)
        {
            this.Location = new double[2] { x, y };
            this.Type = type;
        }
    }
}

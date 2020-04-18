using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    interface ITickLogic
    {
        // Imitates gravity
        void GravityTick();

        bool FuelTick();
    }
}

using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    interface IDbLogic
    {
        void SaveGame(Drill drill, List<Mineral> minerals);

        void LoadGame();
    }
}

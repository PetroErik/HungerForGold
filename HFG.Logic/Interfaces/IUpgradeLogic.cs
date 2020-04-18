using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic.Interfaces
{
    interface IUpgradeLogic
    {
        void UpgradeDrill();

        void UpgradeStorage();

        void UpgradeFuelTank();
    }
}

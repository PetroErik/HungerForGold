using HFG.Display;
using HFG.Logic.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic.Logic
{
    public class UpgradeLogic : IUpgradeLogic
    {
        GameModel gameModel;

        public UpgradeLogic(GameModel model)
        {
            this.gameModel = model;
        }

        public void UpgradeDrill()
        {
            if (this.gameModel.drill.DrillLvl < CONFIG.MaxDrillLevel)
            {
                this.gameModel.drill.DrillLvl++;
            }
        }

        public void UpgradeFuelTank()
        {
            if (this.gameModel.drill.FuelTankLvl < CONFIG.MaxFuelTankLevel)
            {
                this.gameModel.drill.FuelTankLvl++;
                this.gameModel.drill.FuelCapacity = this.gameModel.drill.FuelTankLvl * 100;
            }
        }

        public void UpgradeStorage()
        {
            if (this.gameModel.drill.StorageLvl < CONFIG.MaxStorageLevel)
            {
                this.gameModel.drill.StorageLvl++;
                this.gameModel.drill.StorageCapacity = this.gameModel.drill.StorageLvl * 100;

            }
        }
    }
}

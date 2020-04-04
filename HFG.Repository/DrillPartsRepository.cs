using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    public class DrillPartsRepository : IRepository
    {
        int StorageLvl = 1;
        int DrillLvl = 1;
        int FuelTankLvl = 1;
        int ActualStorageSize = Config.StorageLvl1;
        int ActualFuelTankSize = Config.FuelTankLvl1;
        int AtualDrillSize = Config.DrillLvl1;

        int TotalPoints;
        int ActualPoints;
        int StorageFullness;

        public int calcTotalPoints(int actualPoints)
        {
            throw new NotImplementedException();
        }

        public void clearStorage()
        {
            throw new NotImplementedException();
        }

        public void collectBricks(BricksType brick)
        {
            throw new NotImplementedException();
        }

        public void moveDrill(Direction d)
        {
            throw new NotImplementedException();
        }

        public int upgradeDrill()
        {
            throw new NotImplementedException();
        }

        public int upgradeFuelTank()
        {
            throw new NotImplementedException();
        }

        public int upgradeStorage()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    public class DrillPartsRepository : IRepository
    {
        int ActualStorageLvl = Config.StorageLvl1;
        int ActualFuelTankLvl = Config.FuelTankLvl1;
        int AtualDrillLvl = Config.DrillLvl1;

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

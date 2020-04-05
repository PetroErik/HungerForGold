using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Repository
{
    //interface IRepository
    //{
    //    // adds different amount of points to the ActualPoints depending in the type of the brick
    //    // only adds points until the storage is not reached the maximum capiblity of its level
    //    // for example if the storageLevel = 1 ==> only StorageLvl1 amount of points can be collected 
    //    void collectBricks(BricksType brick);

    //    // Add the actualPoints to the TotalPoints. 
    //    // This will be called in the logic if the reachGround() method returns true.
    //    int calcTotalPoints(int actualPoints);

    //    // Changes the X Y coordinate of the drill based on the input. 
    //    // I am not sure yet how it should be implemented properly so maybe we should wait until we know how to use imagebrushes.
    //    void moveDrill(Direction d);

    //    // this will also be called in the logic when the reachGround() returns true
    //    // sets the storage to 0;
    //    void clearStorage();

    //    int upgradeDrill();

    //    int upgradeStorage();

    //    int upgradeFuelTank();
    //}
}

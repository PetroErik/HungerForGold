using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFG.Display;

namespace HFG.Logic
{
    public interface IGameLogic
    {

        void InitialMap();

        // adds different amount of points to the ActualPoints depending in the type of the brick
        // only adds points until the storage is not reached the maximum capiblity of its level
        void CollectMinerals(Mineral min);

        // Add the actualPoints to the TotalPoints. 
        // This will be called in the logic if the reachGround() method returns true.
        void CalcTotalPoints();

        // Changes the X Y coordinate of the drill based on the input. 
        // I am not sure yet how it should be implemented properly so maybe we should wait until we know how to use imagebrushes.
        void MoveDrill(int dx, int dy);

        // this will also be called in the logic when the reachGround() returns true
        // sets the storage to 0;
        void ClearStorage();

        // Imitates gravity
        void GravityTick();

        bool FuelTick();

        bool Upgradeable();

        void UpgradeDrill();

        void UpgradeStorage();

        void UpgradeFuelTank();

        void SaveGame(Drill drill, List<Mineral> minerals);

        void LoadGame();
    }
}

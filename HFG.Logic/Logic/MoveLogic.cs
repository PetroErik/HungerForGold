using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    public class MoveLogic : IMoveLogic
    {
        GameModel gameModel;

        public MoveLogic(GameModel model)
        {
            this.gameModel = model;        
        }

        // When calling the MoveDrill(dx,dy) method in GameControl ==> dx and dy are equal to mode.drill.DrillLvl
        public void MoveDrill(int dx, int dy)
        {
            double newX = (this.gameModel.drill.Location[0] + (dx * this.gameModel.TileSize));
            double newY = (this.gameModel.drill.Location[1] + (dy * this.gameModel.TileSize));
            double startingPointToDrill = this.gameModel.GameHeight / 2 - this.gameModel.TileSize * 4;

            if (newX >= -1 && newY >= startingPointToDrill -10 && newX <= this.gameModel.GameWidth && newY <= this.gameModel.GameHeight)
            {
                this.gameModel.drill.Location[0] = newX;
                this.gameModel.drill.Location[1] = newY;
            }
            if (CollisionWithSilo())
            {
                CalcTotalPoints();
                ClearStorage();
            }
            //foreach (Mineral mineral in this.gameModel.Minerals)
            //{
            //    CollectMinerals(mineral);
            //}
        }

        public bool CollisionWithSilo()
        {
            return this.gameModel.drill.Location[0].Equals(this.gameModel.SiloHouse.Location[0]) 
                && this.gameModel.drill.Location[1].Equals(this.gameModel.SiloHouse.Location[1]);
        }

        public void CalcTotalPoints()
        {
            this.gameModel.TotalPoints += this.gameModel.ActualPoints;
        }

        public void ClearStorage()
        {
            this.gameModel.drill.StorageFullness = 0;
            this.gameModel.ActualPoints = 0;
        }

        public void CollectMinerals(Mineral min)
        {
            if (this.gameModel.drill.Location[1].Equals(min.Location[1]) && 
                this.gameModel.drill.Location[0].Equals(min.Location[0]) 
                && this.gameModel.drill.StorageFullness < this.gameModel.drill.StorageCapacity)
            {
                switch (min.Type)
                {
                    case MineralsType.Gold:
                        this.gameModel.ActualPoints += CONFIG.GoldPrice; this.gameModel.drill.StorageFullness++;
                        break;
                    case MineralsType.Silver:
                        this.gameModel.ActualPoints += CONFIG.SilverPrice; this.gameModel.drill.StorageFullness++;
                        break;
                    case MineralsType.Bronze:
                        this.gameModel.ActualPoints += CONFIG.BronzePrice; this.gameModel.drill.StorageFullness++;
                        break;
                }
            }
        }
    }
}

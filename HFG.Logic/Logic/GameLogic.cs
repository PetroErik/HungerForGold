using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HFG.Display;
using HFG.Repository;
using HFG.Database;
using HFG.Repository.Repository;
using HFG.Logic.Logic;

namespace HFG.Logic
{
    public class GameLogic : IGameLogic
    {
        public GameModel gameModel;
        public MoveLogic moveLogic;
        public DbLogic dbLogic;
        public TickLogic tickLogic;
        public UpgradeLogic upgradeLogic;

        static HFGEntities entities = new HFGEntities();
        
        public GameLogic(GameModel model)
        {
            this.gameModel = model;
            this.moveLogic = new MoveLogic(model);
            this.dbLogic = new DbLogic(model, new DrillRepository(entities), new BrickRepository(entities), new ConnRepository(entities));
            this.tickLogic = new TickLogic(model);
            this.upgradeLogic = new UpgradeLogic(model);
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
        }

        static Random R = new Random();
        public void InitialMap()
        {
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
            this.gameModel.TotalPoints = 0;
            this.gameModel.ActualPoints = 0;
            this.gameModel.drill = new Drill(CONFIG.MapWidth * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize);                                // Ground level is at GameHeight / 3
            this.gameModel.SiloHouse = new SiloHouse(CONFIG.MapWidth * 3 / 2 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);     // Silo is 4 tile higher than the drill
            this.gameModel.MachinistHouse = new MachinistHouse(CONFIG.MapWidth / 4 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);
            this.gameModel.Minerals = new List<Mineral>();

            for (int i = 0; i < 30; i++)
            {
                int typeSelector = R.Next(0, 3);
                if (typeSelector == 0)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Bronze)); // + 2 to avoid gameModel.Mineralss on the ground level
                }
                if (typeSelector == 1)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Silver));
                }
                if (typeSelector == 2)
                {
                    gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Gold));
                }
            }
        }
    }
}

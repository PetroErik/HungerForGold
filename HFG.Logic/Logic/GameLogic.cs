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


namespace HFG.Logic
{
    /// <summary>
    /// OVERALL LOGIC FOR GAME. INITIAL MAP, START NEW GAME, DETECT WHEN GAME IS OVER
    /// </summary>
    public class GameLogic : IGameLogic
    {
        public GameModel gameModel;
        public MoveLogic moveLogic;
        public DbLogic dbLogic;
        public TickLogic tickLogic;

        
        public GameLogic(GameModel model)
        {
            HFGEntities entities = new HFGEntities();
            this.gameModel = model;
            this.moveLogic = new MoveLogic(model);
            this.dbLogic = new DbLogic(model, new DrillRepository(entities), new BrickRepository(entities), new ConnRepository(entities));
            this.tickLogic = new TickLogic(model);
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
        }

        static Random R = new Random();

        public void startGame()
        {
            this.gameModel.drill.Location[0] = CONFIG.MapWidth * this.gameModel.TileSize;
            this.gameModel.drill.Location[1] = CONFIG.MapHeight / 3 * this.gameModel.TileSize;
            this.gameModel.drill.initialValue();
            this.gameModel.TotalPoints = 0;
            this.gameModel.ActualPoints = 0;
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
        public void InitialMap()
        {
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
            
            this.gameModel.drill = new Drill(CONFIG.MapWidth * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize);                                // Ground level is at GameHeight / 3
            this.gameModel.SiloHouse = new SiloHouse(CONFIG.MapWidth * 3 / 2 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);     // Silo is 4 tile higher than the drill
            this.gameModel.MachinistHouse = new MachinistHouse(CONFIG.MapWidth / 4 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);           
        }

        public bool GameOver()
        {
            return this.gameModel.drill.FuelTankFullness <= 0;
        }
    }
}

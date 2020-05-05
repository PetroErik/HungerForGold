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
using HFG.Display.Elements;

namespace HFG.Logic
{
    /// <summary>
    /// OVERALL LOGIC FOR GAME. INITIAL MAP, START NEW GAME, DETECT WHEN GAME IS OVER
    /// </summary>
    public class GameLogic : IGameLogic
    {
        static Random R = new Random();
        public GameModel gameModel;
        public MoveLogic moveLogic;
        public DbLogic dbLogic;
        public TickLogic tickLogic;

        /// <summary>
        /// Initializes a new instance of the <see cref="GameLogic"/> class.
        /// Initiates properties of logics and model.
        /// </summary>
        /// <param name="model">GameModel parameter help the initialization of properties.</param>
        public GameLogic(GameModel model)
        {
            HFGEntities entities = new HFGEntities();
            this.gameModel = model;
            this.moveLogic = new MoveLogic(model);
            this.dbLogic = new DbLogic(model, new DrillRepository(entities), new BrickRepository(entities), new ConnRepository(entities));
            this.tickLogic = new TickLogic(model);
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);
            this.gameModel.MenuButton = new double[] { 0, 0, 30, 20 };
            this.gameModel.StartButton = new double[] {this.gameModel.GameWidth / 2 - 180, this.gameModel.GameHeight / 2, 400, 40};
            this.gameModel.ContinueButton = new double[] { (this.gameModel.GameWidth / 2) - 180, this.gameModel.GameHeight / 2 + 60, 400, 40 };
            this.gameModel.HighscoreButton = new double[] { this.gameModel.GameWidth / 2 - 180, this.gameModel.GameHeight / 2 + 120, 400, 40 };
            this.gameModel.Bombs = new List<Bomb>();
            for (int i = 0; i < CONFIG.NmbOfBombs; i++)
            {
                this.gameModel.Bombs.Add(new Bomb((double)(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize), (double)(R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize)));
            }

            this.gameModel.Enemies = new List<Enemy>();
            for (int i = 0; i < CONFIG.NmbOfEnemies; i++)
            {
                this.gameModel.Enemies.Add(new Enemy((double)(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize), (double)(R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize)));
            }
        }

        /// <summary>
        /// Sets the initial state of the game.
        /// </summary>
        public void StartGame()
        {
            this.gameModel.drill.Location[0] = CONFIG.MapWidth * this.gameModel.TileSize;
            this.gameModel.drill.Location[1] = CONFIG.MapHeight / 3 * this.gameModel.TileSize;
            this.gameModel.drill.initialValue();
            this.gameModel.TotalPoints = 0;
            this.gameModel.ActualPoints = 0;
            this.gameModel.Minerals = new List<Mineral>();
            for (int i = 0; i < CONFIG.NmbOfMinerals; i++)
            {
                int typeSelector = R.Next(0, 3);
                if (typeSelector == 0)
                {
                    this.gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Bronze)); // + 2 to avoid gameModel.Mineralss on the ground level
                }

                if (typeSelector == 1)
                {
                    this.gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Silver));
                }

                if (typeSelector == 2)
                {
                    this.gameModel.Minerals.Add(new Mineral(R.Next(0, CONFIG.MapWidth * 2) * this.gameModel.TileSize, (R.Next(CONFIG.MapHeight / 3 + 2, CONFIG.MapHeight) * this.gameModel.TileSize), MineralsType.Gold));
                }
            }
        }

        /// <summary>
        /// Sets the initial state of the map.
        /// </summary>
        public void InitialMap()
        {
            this.gameModel.TileSize = Math.Min(this.gameModel.GameWidth / CONFIG.MapWidth, this.gameModel.GameHeight / CONFIG.MapHeight);

            this.gameModel.drill = new Drill(CONFIG.MapWidth * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize);                                // Ground level is at GameHeight / 3
            this.gameModel.SiloHouse = new SiloHouse(CONFIG.MapWidth * 3 / 2 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);     // Silo is 4 tile higher than the drill
            this.gameModel.MachinistHouse = new MachinistHouse(CONFIG.MapWidth / 4 * this.gameModel.TileSize, CONFIG.MapHeight / 3 * this.gameModel.TileSize - 4 * this.gameModel.TileSize);           
        }

        /// <summary>
        /// Decide if the game is still on or it is over.
        /// </summary>
        /// <returns>Return value defines the state of the game. If the value is true, the game is over.</returns>
        public bool GameOver()
        {
            return this.gameModel.drill.FuelTankFullness <= 0 || this.moveLogic.CollisionWithEnemy() || this.moveLogic.CollisionWithBomb();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HFG.Display;

namespace HFG.Logic
{
    /// <summary>
    /// game logic for initial map and mapping the game 
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// create the houses
        /// </summary>
        void InitialMap();

        /// <summary>
        /// create the drill and the list of minerals
        /// </summary>
        void StartGame();

        /// <summary>
        /// Check is the Game is Over.
        /// </summary>
        /// <returns>True if the Game is Over.</returns>
        bool GameOver();
    }
}

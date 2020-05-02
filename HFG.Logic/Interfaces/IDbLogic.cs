using HFG.Display;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HFG.Logic
{
    /// <summary>
    /// Interface for the logic of the Database.
    /// </summary>
    interface IDbLogic
    {
        /// <summary>
        /// Saves the state of the game.
        /// </summary>
        /// <param name="drill">Drill to be saved.</param>
        /// <param name="minerals">Minerals to be saved.</param>
        void SaveGame(Drill drill, List<Mineral> minerals);

        /// <summary>
        /// Loads the previous state of the game.
        /// </summary>
        /// <returns>True if there is a saved game in the Database</returns>
        bool LoadGame();

        /// <summary>
        /// Lists the highest scores.
        /// </summary>
        /// <returns>List of the 5 highest score.</returns>
        List<int?> Highscore();
    }
}

// <copyright file="IGameLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    /// <summary>
    /// game logic for initial map and mapping the game.
    /// </summary>
    public interface IGameLogic
    {
        /// <summary>
        /// Create the houses.
        /// </summary>
        void InitialMap();

        /// <summary>
        /// Create the drill and the list of minerals.
        /// </summary>
        void StartGame();

        /// <summary>
        /// Check is the Game is Over.
        /// </summary>
        /// <returns>True if the Game is Over.</returns>
        bool GameOver();
    }
}

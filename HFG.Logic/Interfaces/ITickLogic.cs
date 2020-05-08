// <copyright file="ITickLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    /// <summary>
    /// Interface for tick logic.
    /// </summary>
    public interface ITickLogic
    {
        /// <summary>
        /// Decreases the FuelTankFullness by 1.
        /// </summary>
        void FuelTick();

        /// <summary>
        /// Moves enemies.
        /// </summary>
        void EnemyTick();

        /// <summary>
        /// Decreases the time by 1 until explode.
        /// </summary>
        void BoomTick();
    }
}

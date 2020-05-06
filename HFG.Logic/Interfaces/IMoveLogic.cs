// <copyright file="IMoveLogic.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Logic
{
    using HFG.Display;

    /// <summary>
    /// Interface for the movement of the drill.
    /// </summary>
    public interface IMoveLogic
    {
        /// <summary>
        /// Collects a mineral that the drill is colliding with.
        /// </summary>
        /// <param name="min">Mineral that is collected.</param>
        void CollectMinerals(Mineral min);

        /// <summary>
        /// Calculates the total points.
        /// </summary>
        void CalcTotalPoints();

        /// <summary>
        /// Moves the drill to x and y direction.
        /// </summary>
        /// <param name="dx">Movement to the x direction.</param>
        /// <param name="dy">Movement to the y direction.</param>
        void MoveDrill(int dx, int dy);

        /// <summary>
        /// Sets the storage fullness to 0.
        /// </summary>
        void ClearStorage();

        /// <summary>
        /// Upgrades the drill.
        /// </summary>
        void UpgradeDrill();

        /// <summary>
        /// Upgrades the FuelTank element.
        /// </summary>
        void UpgradeFuelTank();

        /// <summary>
        /// Upgrades the Storage element.
        /// </summary>
        void UpgradeStorage();


    }
}

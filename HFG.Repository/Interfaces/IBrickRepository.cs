// <copyright file="IBrickRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Repository
{
    using HFG.Database;

    /// <summary>
    /// Interface for Brick repository.
    /// </summary>
    public interface IBrickRepository : IRepository<brick>
    {
        /// <summary>
        /// method for changing the location of Brick.
        /// </summary>
        /// <param name="brick">selected brick .</param>
        /// <param name="x">x coordinate .</param>
        /// <param name="y">y coordinate .</param>
        void ChangeLocation(brick brick, int x, int y);
    }
}

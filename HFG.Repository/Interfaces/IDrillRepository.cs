// <copyright file="IDrillRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Repository
{
    using HFG.Database;

    /// <summary>
    /// interface of drill repository.
    /// </summary>
    public interface IDrillRepository : IRepository<drill>
    {
        /// <summary>
        /// method to change the location of the drill.
        /// </summary>
        /// <param name="drill">selected drill.</param>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        void ChangeLocation(drill drill, int x, int y);
    }
}

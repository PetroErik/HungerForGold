// <copyright file="DrillRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Repository
{
    using System.Data.Entity;
    using HFG.Database;

    /// <summary>
    /// Repository for drill .
    /// </summary>
    public class DrillRepository : EfRepository<drill>, IDrillRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DrillRepository"/> class.
        /// constructor for Drill repository .
        /// </summary>
        /// <param name="ctx">databse context .</param>
        public DrillRepository(DbContext ctx)
            : base(ctx)
        {
        }

        /// <summary>
        /// method to change the location of the drill.
        /// </summary>
        /// <param name="drill">selected drill.</param>
        /// <param name="x">x coordinate.</param>
        /// <param name="y">y coordinate.</param>
        public void ChangeLocation(drill drill, int x, int y)
        {
            drill.drill_x = x;
            drill.drill_y = y;
            this.Ctx.SaveChanges();
        }
    }
}

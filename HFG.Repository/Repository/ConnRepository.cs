// <copyright file="ConnRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Repository
{
    using System.Data.Entity;
    using HFG.Database;

    /// <summary>
    /// connection repository .
    /// </summary>
    public class ConnRepository : EfRepository<conn>, IConnRepository
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnRepository"/> class.
        /// Constructor for Conn repository .
        /// </summary>
        /// <param name="ctx">Database context .</param>
        public ConnRepository(DbContext ctx)
            : base(ctx)
        {
        }
    }
}

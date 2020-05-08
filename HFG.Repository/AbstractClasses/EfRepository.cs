// <copyright file="EfRepository.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace HFG.Repository
{
    using System.Data.Entity;
    using System.Linq;

    /// <summary>
    /// abstract class has basic functions that all repositories have.
    /// </summary>
    /// <typeparam name="TEntity">type of repository entity.</typeparam>
    public abstract class EfRepository<TEntity> : IRepository<TEntity>
            where TEntity : class
        {
            /// <summary>
            /// database context .
            /// </summary>
            private DbContext ctx;

            /// <summary>
            /// Initializes a new instance of the <see cref="EfRepository{TEntity}"/> class.
            /// </summary>
            /// <param name="ctx">databasecontext .</param>
            public EfRepository(DbContext ctx)
            {
                this.ctx = ctx;
            }

            /// <summary>
            /// Gets or sets encapsulation data of database context.
            /// </summary>
            protected DbContext Ctx { get => this.ctx; set => this.ctx = value; }

            /// <summary>
            /// method to add new instance .
            /// </summary>
            /// <param name="newinstance">new entity instance.</param>
            public void Addnew(TEntity newinstance)
            {
                this.Ctx.Set<TEntity>().Add(newinstance);
                this.Ctx.SaveChanges();
            }

            /// <summary>
            /// method to delete instance .
            /// </summary>
            /// <param name="instance">entity instance.</param>
            public void Delete(TEntity instance)
            {
                this.Ctx.Set<TEntity>().Remove(instance);
                this.Ctx.SaveChanges();
            }

            /// <summary>
            /// method to return collection of entity.
            /// </summary>
            /// <returns>IQueryable entity instance.</returns>
            public IQueryable<TEntity> GetAll()
            {
                return this.Ctx.Set<TEntity>();
            }

            /// <summary>
            /// method to return 1 instance.
            /// </summary>
            /// <param name="id">id of the instance.</param>
            /// <returns>an entity instance.</returns>
            public TEntity GetOne(int id)
            {
                return this.Ctx.Set<TEntity>().Find(id);
            }
        }
    }

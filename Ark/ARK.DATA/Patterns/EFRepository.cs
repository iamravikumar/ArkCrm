using ARK.CORE;
using ARK.CORE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ARK.DATA.Patterns
{

    /// <summary>
    /// Represents the Entity Framework repository
    /// </summary>
    /// <typeparam name="TEntity">Entity type</typeparam>
    public partial class EfRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        #region Fields

        //private readonly IDbContext _context;
        private readonly ARK.DATA.Models.ArkDatabaseContext _context;

        private DbSet<TEntity> _entities;

        #endregion

        #region Ctor

        public EfRepository(ARK.DATA.Models.ArkDatabaseContext context)
        {
            _context = context;
        }

        #endregion

        #region Utilities

        /// <summary>
        /// Rollback of entity changes and return full error message
        /// </summary>
        /// <param name="exception">Exception</param>
        /// <returns>Error message</returns>
        protected string GetFullErrorTextAndRollbackEntityChanges(DbUpdateException exception)
        {
            //rollback entity changes
            if (_context is DbContext dbContext)
            {
                var entries = dbContext.ChangeTracker.Entries()
                    .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified).ToList();

                entries.ForEach(entry =>
                {
                    try
                    {
                        entry.State = EntityState.Unchanged;
                    }
                    catch (InvalidOperationException)
                    {
                        // ignored
                    }
                });
            }

            try
            {
                _context.SaveChanges();
                return exception.ToString();
            }
            catch (Exception ex)
            {
                //if after the rollback of changes the context is still not saving,
                //return the full text of the exception that occurred when saving
                return ex.ToString();
            }
        }

        #endregion

        #region Methods

        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        public virtual TEntity GetById(object id)
        {
            return Entities.Find(id);
        }

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Insert(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Insert(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.AddRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Update(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            try
            {
                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Update entities
        /// </summary>
        /// <param name="entities">Entities</param>
        public virtual void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            try
            {
                Entities.UpdateRange(entities);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }
        }

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        public virtual void Delete(int id)
        {
            if (id == 0)
                throw new ArgumentNullException(nameof(TEntity));

            try
            {
                var exp = CORE.ExpressionHelper.CustomExpression.MakeExpression<TEntity>(Entities, "Id");

                var entity = Entities.FirstOrDefault(exp);


                var propertyInfo = typeof(TEntity).GetType().GetProperty("IsDeleted");
                if (propertyInfo != null) propertyInfo.SetValue(entity, Convert.ChangeType(true, propertyInfo.PropertyType), null);

                Entities.Update(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                //ensure that the detailed error text is saved in the Log
                throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            }

            //if (entity == null)
            //    throw new ArgumentNullException(nameof(entity));

            //try
            //{
            //    Entities.Remove(entity);
            //    _context.SaveChanges();
            //}
            //catch (DbUpdateException exception)
            //{
            //    //ensure that the detailed error text is saved in the Log
            //    throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
            //}
        }

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        //public virtual void Delete(IEnumerable<int> ids)
        //{
        //    if (ids.Count() <= 0)
        //        throw new ArgumentNullException(nameof(Entities));

        //    try
        //    {

        //        //var exp = Helpers.CustomExpression.MakeExpression<TEntity>(Entities, "Id");
        //        //var entity = Entities.FirstOrDefault(exp);


        //        //var propertyInfo = typeof(TEntity).GetType().GetProperty("IsDeleted");
        //        //if (propertyInfo != null) propertyInfo.SetValue(entity, Convert.ChangeType(true, propertyInfo.PropertyType), null);

        //        //Entities.Update(entity);
        //        //_context.SaveChanges();

        //        var asd = _context.

        //        foreach (var item in ids)
        //        {
        //            var propertyInfo = item.GetType().GetProperty("IsDeleted");
        //            if (propertyInfo != null) propertyInfo.SetValue(item, Convert.ChangeType(true, propertyInfo.PropertyType), null);
        //        }

        //        Entities.UpdateRange(entities);
        //        _context.SaveChanges();
        //    }
        //    catch (DbUpdateException exception)
        //    {
        //        //ensure that the detailed error text is saved in the Log
        //        throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
        //    }

        //    //if (entities == null)
        //    //    throw new ArgumentNullException(nameof(entities));

        //    //try
        //    //{
        //    //    Entities.RemoveRange(entities);
        //    //    _context.SaveChanges();
        //    //}
        //    //catch (DbUpdateException exception)
        //    //{
        //    //    //ensure that the detailed error text is saved in the Log
        //    //    throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
        //    //}
        //}

        //public IQueryable<TEntity> QueryType()
        //{
        //    return _context.Query<TEntity>();
        //}

        #endregion

        #region Properties

        /// <summary>
        /// Gets a table
        /// </summary>
        public virtual IQueryable<TEntity> Table => Entities;

        /// <summary>
        /// Gets a table with "no tracking" enabled (EF feature) Use it only when you load record(s) only for read-only operations
        /// </summary>
        public virtual IQueryable<TEntity> TableNoTracking => Entities.AsNoTracking();

        /// <summary>
        /// Gets an entity set
        /// </summary>
        protected virtual DbSet<TEntity> Entities
        {
            get
            {
                if (_entities == null)
                    _entities = _context.Set<TEntity>();

                return _entities;
            }
        }

        #endregion
    }
}

///// <summary>
///// Delete entity
///// </summary>
///// <param name="entity">Entity</param>
//public virtual void DeleteAb(long id)
//{
//    if (id <= 0)
//        throw new ArgumentNullException(nameof(T));

//    try
//    {
//        Entities.Remove();
//        _context.SaveChanges();
//    }
//    catch (DbUpdateException exception)
//    {
//        //ensure that the detailed error text is saved in the Log
//        throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
//    }
//}

///// <summary>
///// Delete entities
///// </summary>
///// <param name="entities">Entities</param>
//public virtual void DeleteAb(IEnumerable<long> ids)
//{
//    if (entities == null)
//        throw new ArgumentNullException(nameof(entities));

//    try
//    {
//        Entities.RemoveRange(entities);
//        _context.SaveChanges();
//    }
//    catch (DbUpdateException exception)
//    {
//        //ensure that the detailed error text is saved in the Log
//        throw new Exception(GetFullErrorTextAndRollbackEntityChanges(exception), exception);
//    }
//}
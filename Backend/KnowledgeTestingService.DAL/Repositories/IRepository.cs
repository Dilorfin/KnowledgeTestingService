using KnowledgeTestingService.DAL.Entities.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories
{
    public interface IRepository<TEntity> : IDisposable
        where TEntity : Entity
    {
        /// <summary>
        /// Gets entity by id from data source.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Returns entity by id</returns>
        Task<TEntity> GetAsync(int id);

        /// <summary>
        /// Gets all entities from data source.
        /// </summary>
        /// <returns>Returns all entities</returns>
        IQueryable<TEntity> GetAll();

        /// <summary>
        /// Deletes entity by id in data source.
        /// </summary>
        /// <param name="id">Entity id</param>
        void Delete(int id);

        /// <summary>
        /// Adds entity to data source.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(TEntity entity);

        /// <summary>
        /// Updates entity in data source.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(TEntity entity);

        /// <summary>
        /// Checks if entity with id exist in data source.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Returns flag whether entity exists in data source</returns>
        Task<bool> ContainsEntityWithId(int id);
    }
}
using KnowledgeTestingService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Tests
{
    public interface ITestRepository : IDisposable
    {
        /// <summary>
        /// Get certain amount of entities starting from specified offset.
        /// </summary>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <returns>Returns count of entities from the offset</returns>
        Task<IEnumerable<Test>> GetRange(int offset, int count);

        /// <summary>
        /// Counts tests
        /// </summary>
        /// <returns>Returns number of tests</returns>
        Task<long> LongCountAsync();

        /// <summary>
        /// Get certain amount of entities that contains filter starting from specified offset.
        /// </summary>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <param name="filter">String to contain</param>
        /// <returns>Returns filtered count of entities from the offset</returns>
        Task<IEnumerable<Test>> GetRange(int offset, int count, string filter);

        /// <summary>
        /// Counts tests contains filter string
        /// </summary>
        /// <param name="filter">Filter to match</param>
        /// <returns>Returns number of tests that match filter</returns>
        Task<long> LongCountAsync(string filter);

        /// <summary>
        /// Gets entity by id from data source.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Returns entity by id</returns>
        Task<Test> GetAsync(int id);

        /// <summary>
        /// Adds entity to data source.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(Test entity);

        /// <summary>
        /// Updates entity in data source.
        /// </summary>
        /// <param name="entity">Entity to update</param>
        void Update(Test entity);

        /// <summary>
        /// Deletes entity from data source.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(Test entity);
    }
}
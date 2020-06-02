using KnowledgeTestingService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.TestResults
{
    public interface ITestResultRepository : IDisposable
    {
        /// <summary>
        /// Gets entity by id from data source.
        /// </summary>
        /// <param name="id">Entity id</param>
        /// <returns>Returns entity by id</returns>
        Task<TestResult> GetAsync(int id);
        
        /// <summary>
        /// Adds entity to data source.
        /// </summary>
        /// <param name="entity">Entity to add</param>
        void Add(TestResult entity);

        /// <summary>
        /// Get certain amount of user's test results starting from specified offset.
        /// </summary>
        /// <param name="userId">User's id whose results will be returned</param>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <returns>Returns count of entities from the offset</returns>
        Task<IEnumerable<TestResult>> GetRangeByUser(string userId, int offset, int count);

        /// <summary>
        /// Counts test results of certain user
        /// </summary>
        /// <param name="userId">Id of user whose results to count</param>
        /// <returns>Returns number of user's test results</returns>
        Task<long> LongCountAsync(string userId);
        
        /// <summary>
        /// Get test results for range of tests
        /// </summary>
        /// <param name="testIds">Ids of tests</param>
        /// <returns>Returns test results for tests</returns>
        Task<IEnumerable<TestResult>> GetAllByTestsRange(IEnumerable<int> testIds);
    }
}
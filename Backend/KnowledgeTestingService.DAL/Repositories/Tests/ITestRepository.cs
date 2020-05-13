using KnowledgeTestingService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Tests
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<long> LongCountAsync();
        Task<long> LongCountAsync(string filter);
        
        /// <summary>
        /// Get certain amount of entities that contains starting from specified offset.
        /// </summary>
        /// <param name="offset">Number of entities to skip</param>
        /// <param name="count">Number of entities to return</param>
        /// <param name="filter"></param>
        /// <returns>Returns filtered count of entities from the offset</returns>
        Task<IEnumerable<Test>> GetAll(int offset, int count, string filter);
    }
}
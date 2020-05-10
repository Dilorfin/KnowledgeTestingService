using System.Threading.Tasks;
using KnowledgeTestingService.DAL.Entities;

namespace KnowledgeTestingService.DAL.Repositories.Tests
{
    public interface ITestRepository : IRepository<Test>
    {
        Task<long> LongCountAsync();
    }
}
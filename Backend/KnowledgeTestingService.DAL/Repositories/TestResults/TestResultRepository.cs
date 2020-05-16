using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.TestResults
{
    public class TestResultRepository : Repository, ITestResultRepository
    {
        private readonly DbSet<TestResult> testResults;

        public TestResultRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            testResults = dbContext.TestResults;
        }

        public async Task<TestResult> GetAsync(int id)
        {
            return await testResults
                .Include(tr => tr.Test)
                .FirstOrDefaultAsync(tr => tr.Id == id);
        }

        public void Add(TestResult entity)
        {
            testResults.Add(entity);
        }

        public async Task<IEnumerable<TestResult>> GetAllUsersTestResults(string userId, int offset, int count)
        {
            return await testResults
                .Where(tr => tr.UserId == userId)
                .Skip(offset)
                .Take(count)
                .Include(tr => tr.Test)
                .ToListAsync();
        }

        public async Task<long> LongCountAsync(string userId)
        {
            return await testResults
                .Where(tr => tr.UserId == userId)
                .LongCountAsync();
        }

        public async Task<IEnumerable<TestResult>> GetTestResultsForTestsRange(IEnumerable<int> testIds)
        {
            return await testResults
                .Where(tr => testIds.Contains(tr.TestId))
                .ToListAsync();
        }
    }
}
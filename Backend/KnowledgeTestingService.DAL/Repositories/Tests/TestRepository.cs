using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Tests
{
    public class TestRepository : Repository, ITestRepository
    {
        private readonly DbSet<Test> tests;

        public TestRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.tests = dbContext.Tests;
        }

        public async Task<IEnumerable<Test>> GetRange(int offset, int count)
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public async Task<long> LongCountAsync()
        {
            return await tests.LongCountAsync();
        }

        public async Task<IEnumerable<Test>> GetRange(int offset, int count, string filter)
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .Where(t => t.Title.Contains(filter))
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public async Task<long> LongCountAsync(string filter)
        {
            return await tests
                .Where(t => t.Title.Contains(filter))
                .LongCountAsync();
        }

        public async Task<Test> GetAsync(int id)
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public void Add(Test entity)
        {
            tests.Add(entity);
        }

        public void Update(Test entity)
        {
            tests.Update(entity);
        }

        public void Delete(Test entity)
        {
            tests.Remove(entity);
        }
    }
}
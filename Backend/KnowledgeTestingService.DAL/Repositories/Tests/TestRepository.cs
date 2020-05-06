using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Tests
{
    public class TestRepository : Repository<Test>, ITestRepository
    {
        private readonly DbSet<Test> tests;

        public TestRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.tests = dbContext.Tests;
        }

        public override async Task<Test> GetAsync(int id)
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public override async Task<IEnumerable<Test>> GetAll()
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Test>> GetAll(int offset, int count)
        {
            return await tests
                .Include(t => t.Questions)
                .ThenInclude(q => q.Answers)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public override void Delete(int id)
        {
            var test = new Test { Id = id };
            tests.Remove(test);
        }

        public override void Add(Test entity)
        {
            tests.Add(entity);
        }

        public override void Update(Test entity)
        {
            tests.Update(entity);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await tests.AnyAsync(t => t.Id == id);
        }
    }
}
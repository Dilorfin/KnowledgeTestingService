using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Answers
{
    public class AnswerRepository : Repository<Answer>, IAnswerRepository
    {
        private readonly DbSet<Answer> answers;

        public AnswerRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.answers = dbContext.Answers;
        }

        public override async Task<Answer> GetAsync(int id)
        {
            return await answers
                .Include(a => a.Question)
                .ThenInclude(q => q.Test)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public override async Task<IEnumerable<Answer>> GetAll()
        {
            return await answers
                .Include(a => a.Question)
                .ThenInclude(q => q.Test)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Answer>> GetAll(int offset, int count)
        {
            return await answers
                .Include(a => a.Question)
                .ThenInclude(q => q.Test)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public override void Delete(Answer entity)
        {
            answers.Remove(entity);
        }

        public override void Add(Answer entity)
        {
            answers.Add(entity);
        }

        public override void Update(Answer entity)
        {
            answers.Update(entity);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await answers.AnyAsync(a => a.Id == id);
        }

        public async Task<IEnumerable<Answer>> GetCorrectAnswersForTest(int testId)
        {
            return await answers.Where(answer => 
                answer.IsCorrect && answer.Question.TestId == testId
            ).ToListAsync();
        }
    }
}
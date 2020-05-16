using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Answers
{
    public class AnswerRepository : Repository, IAnswerRepository
    {
        private readonly DbSet<Answer> answers;

        public AnswerRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.answers = dbContext.Answers;
        }

        public async Task<IEnumerable<Answer>> GetCorrectAnswersForTest(int testId)
        {
            return await answers.Where(answer =>
                answer.IsCorrect && answer.Question.TestId == testId
            ).ToListAsync();
        }

        public void Delete(Answer entity)
        {
            answers.Remove(entity);
        }
    }
}
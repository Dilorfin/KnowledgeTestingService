using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestingService.DAL.Repositories.Questions
{
    public class QuestionRepository : Repository, IQuestionRepository
    {
        private readonly DbSet<Question> questions;

        public QuestionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.questions = dbContext.Questions;
        }

        public void Delete(Question entity)
        {
            questions.Remove(entity);
        }
    }
}
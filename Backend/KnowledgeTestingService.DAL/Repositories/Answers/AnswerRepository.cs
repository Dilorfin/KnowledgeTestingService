using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
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

        public override IQueryable<Answer> GetAll()
        {
            return answers
                .Include(a => a.Question)
                .ThenInclude(q => q.Test);
        }

        public override void Delete(int id)
        {
            var answer = new Answer { Id = id };
            answers.Remove(answer);
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
    }
}
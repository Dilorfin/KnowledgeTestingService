using KnowledgeTestingService.DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Answers
{
    public interface IAnswerRepository : IRepository<Answer>
    {
        Task<IEnumerable<Answer>> GetCorrectAnswersForTest(int testId);
    }
}
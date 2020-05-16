using KnowledgeTestingService.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Answers
{
    public interface IAnswerRepository : IDisposable
    {
        /// <summary>
        /// Get's correct answers for test
        /// </summary>
        /// <param name="testId">Id of the test which answers return</param>
        /// <returns>Returns correct answers for test</returns>
        Task<IEnumerable<Answer>> GetCorrectAnswersForTest(int testId);

        /// <summary>
        /// Deletes entity from data source.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(Answer entity);
    }
}
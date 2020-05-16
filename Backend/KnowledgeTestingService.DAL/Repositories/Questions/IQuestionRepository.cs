using KnowledgeTestingService.DAL.Entities;
using System;

namespace KnowledgeTestingService.DAL.Repositories.Questions
{
    public interface IQuestionRepository : IDisposable
    {
        /// <summary>
        /// Deletes entity from data source.
        /// </summary>
        /// <param name="entity">Entity to delete</param>
        void Delete(Question entity);
    }
}
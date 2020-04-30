using KnowledgeTestingService.DAL.Repositories.Answers;
using KnowledgeTestingService.DAL.Repositories.Questions;
using KnowledgeTestingService.DAL.Repositories.TestResults;
using KnowledgeTestingService.DAL.Repositories.Tests;
using System;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        ITestRepository Tests { get; }
        IQuestionRepository Questions { get; }
        IAnswerRepository Answers { get; }
        ITestResultRepository TestResults { get; }

        Task SaveChangesAsync();
    }
}
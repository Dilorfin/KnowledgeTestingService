using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Repositories.Answers;
using KnowledgeTestingService.DAL.Repositories.Questions;
using KnowledgeTestingService.DAL.Repositories.TestResults;
using KnowledgeTestingService.DAL.Repositories.Tests;
using System;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext dbContext;
        private bool disposed = false;

        private ITestRepository tests;
        private IQuestionRepository questions;
        private IAnswerRepository answers;
        private ITestResultRepository testResults;

        public ITestRepository Tests => tests ??= new TestRepository(dbContext);
        public IQuestionRepository Questions => questions ??= new QuestionRepository(dbContext);
        public IAnswerRepository Answers => answers ??= new AnswerRepository(dbContext);
        public ITestResultRepository TestResults => testResults ??= new TestResultRepository(dbContext);

        public UnitOfWork(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task SaveChangesAsync()
        {
            await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
                answers?.Dispose();
                questions?.Dispose();
                tests?.Dispose();
                testResults?.Dispose();

                dbContext?.Dispose();
            }

            disposed = true;
        }

        ~UnitOfWork()
        {
            Dispose(false);
        }
    }
}
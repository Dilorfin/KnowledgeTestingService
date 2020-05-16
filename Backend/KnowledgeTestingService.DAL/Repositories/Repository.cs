using KnowledgeTestingService.DAL.EF;
using System;

namespace KnowledgeTestingService.DAL.Repositories
{
    public abstract class Repository
    {
        protected readonly ApplicationDbContext DbContext;
        private bool disposed;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public void Dispose()
        {
            this.Dispose(true);
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
                DbContext?.Dispose();
            }

            disposed = true;
        }

        ~Repository()
        {
            Dispose(false);
        }
    }
}
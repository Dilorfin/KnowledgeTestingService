using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities.Base;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : Entity
    {
        protected readonly ApplicationDbContext DbContext;
        private bool disposed;

        protected Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }

        public abstract Task<TEntity> GetAsync(int id);
        public abstract IQueryable<TEntity> GetAll();
        public abstract void Delete(int id);
        public abstract void Add(TEntity entity);
        public abstract void Update(TEntity entity);
        public abstract Task<bool> ContainsEntityWithId(int id);

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
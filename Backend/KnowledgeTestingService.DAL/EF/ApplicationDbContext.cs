using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeTestingService.DAL.EF
{
    public sealed class ApplicationDbContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<TestResult> TestResults { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>()
                .HasMany(t => t.Questions)
                .WithOne(q => q.Test)
                .HasForeignKey(q => q.TestId);

            modelBuilder.Entity<Question>()
                .HasMany(q => q.Answers)
                .WithOne(a => a.Question)
                .HasForeignKey(a => a.QuestionId);

            modelBuilder.Entity<TestResult>()
                .HasOne(tr => tr.Test)
                .WithMany(t => t.TestResults)
                .HasForeignKey(tr => tr.TestId);

            DatabaseSeeder.Seed(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}
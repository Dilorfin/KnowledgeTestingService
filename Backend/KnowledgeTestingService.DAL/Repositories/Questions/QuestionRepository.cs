﻿using KnowledgeTestingService.DAL.EF;
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.DAL.Repositories.Questions
{
    public class QuestionRepository : Repository<Question>, IQuestionRepository
    {
        private readonly DbSet<Question> questions;

        public QuestionRepository(ApplicationDbContext dbContext)
            : base(dbContext)
        {
            this.questions = dbContext.Questions;
        }

        public override async Task<Question> GetAsync(int id)
        {
            return await questions
                .Include(q => q.Test)
                .Include(q => q.Answers)
                .FirstOrDefaultAsync(q => q.Id == id);
        }

        public override async Task<IEnumerable<Question>> GetAll()
        {
            return await questions
                .Include(q => q.Test)
                .Include(q => q.Answers)
                .ToListAsync();
        }

        public override async Task<IEnumerable<Question>> GetAll(int offset, int count)
        {
            return await questions
                .Include(q => q.Test)
                .Include(q => q.Answers)
                .Skip(offset)
                .Take(count)
                .ToListAsync();
        }

        public override void Delete(int id)
        {
            var question = new Question { Id = id };
            questions.Remove(question);
        }

        public override void Add(Question entity)
        {
            questions.Add(entity);
        }

        public override void Update(Question entity)
        {
            questions.Update(entity);
        }

        public override async Task<bool> ContainsEntityWithId(int id)
        {
            return await questions.AnyAsync(q => q.Id == id);
        }
    }
}
using KnowledgeTestingService.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace KnowledgeTestingService.DAL.EF
{
    public static class DatabaseSeeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Test>().HasData(
                new Test
                {
                    Id = 1,
                    Description = "Testing tests",
                    Time = new TimeSpan(0, 5, 0),
                    Title = "Test"
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionText = "What does the raven says in a poem by Edgar Allan Poe \"The Raven\"?",
                    TestId = 1
                }
            );

            modelBuilder.Entity<Answer>().HasData(
                new Answer
                {
                    Id = 1,
                    AnswerText = "Nevermore",
                    IsCorrect = true,
                    QuestionId = 1
                },
                new Answer
                {
                    Id = 2,
                    AnswerText = "Caw!",
                    IsCorrect = false,
                    QuestionId = 1
                }
            );
        }
    }
}
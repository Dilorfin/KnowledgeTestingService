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
                    Title = "Literature test",
                    Description = "Several questions about literature",
                    Time = new TimeSpan(0, 2, 0)
                }
            );

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    Id = 1,
                    QuestionText = "What does the raven says in a poem by Edgar Allan Poe \"The Raven\"?",
                    TestId = 1
                },
                new Question
                {
                    Id = 2,
                    QuestionText = "George Orwell’s Nineteen Eighty-Four was published in which year?",
                    TestId = 1
                },
                new Question
                {
                    Id = 3,
                    QuestionText = "Who wrote The Picture of Dorian Gray?",
                    TestId = 1
                },
                new Question
                {
                    Id = 4,
                    QuestionText = "Which of these is a historical psychological novel in two volumes by Stendhal?",
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
                },
                new Answer
                {
                    Id = 3,
                    AnswerText = "1969",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 4,
                    AnswerText = "1949",
                    IsCorrect = true,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 5,
                    AnswerText = "1947",
                    IsCorrect = false,
                    QuestionId = 2
                },
                new Answer
                {
                    Id = 6,
                    AnswerText = "Oscar Dickson",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 7,
                    AnswerText = "Oscar Wilde",
                    IsCorrect = true,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 8,
                    AnswerText = "Oscar Mayer",
                    IsCorrect = false,
                    QuestionId = 3
                },
                new Answer
                {
                    Id = 9,
                    AnswerText = "The Pink and the Green",
                    IsCorrect = false,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 10,
                    AnswerText = "The Red and the Black",
                    IsCorrect = true,
                    QuestionId = 4
                },
                new Answer
                {
                    Id = 11,
                    AnswerText = "The Black and The White",
                    IsCorrect = false,
                    QuestionId = 4
                }
            );
        }
    }
}
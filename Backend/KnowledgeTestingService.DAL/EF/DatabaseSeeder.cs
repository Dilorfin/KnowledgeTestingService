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
                    Time = new TimeSpan(0, 4, 20)
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
                },
                new Question
                {
                    Id = 5,
                    QuestionText = "Who is not part of Professor Woland's group from The Master and Margarita novel?",
                    TestId = 1
                },
                new Question
                {
                    Id = 6,
                    QuestionText = "What does the White Rabbit call Alice in the novel Alice in Wonderland by Lewis Carroll?",
                    TestId = 1
                },
                new Question
                {
                    Id = 7,
                    QuestionText = "What does Bilbo names his sword in The Hobbit by J. R. R. Tolkien?",
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
                },
                new Answer
                {
                    Id = 12,
                    AnswerText = "A ghoul",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new Answer
                {
                    Id = 13,
                    AnswerText = "A witch",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new Answer
                {
                    Id = 14,
                    AnswerText = "A vampire",
                    IsCorrect = false,
                    QuestionId = 5
                },
                new Answer
                {
                    Id = 15,
                    AnswerText = "A werewolf",
                    IsCorrect = true,
                    QuestionId = 5
                },
                new Answer
                {
                    Id = 16,
                    AnswerText = "Judy",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new Answer
                {
                    Id = 17,
                    AnswerText = "Ginger",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new Answer
                {
                    Id = 18,
                    AnswerText = "Mary Ann",
                    IsCorrect = true,
                    QuestionId = 6
                },
                new Answer
                {
                    Id = 19,
                    AnswerText = "Linda",
                    IsCorrect = false,
                    QuestionId = 6
                },
                new Answer
                {
                    Id = 20,
                    AnswerText = "Slayer",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new Answer
                {
                    Id = 21,
                    AnswerText = "Thorin",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new Answer
                {
                    Id = 22,
                    AnswerText = "Precious",
                    IsCorrect = false,
                    QuestionId = 7
                },
                new Answer
                {
                    Id = 23,
                    AnswerText = "Sting",
                    IsCorrect = true,
                    QuestionId = 7
                }
            );
        }
    }
}
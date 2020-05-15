using AutoMapper;
using KnowledgeTestingService.Common;
using KnowledgeTestingService.DAL.Entities;
using KnowledgeTestingService.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.TestResults.Services
{
    public class TestResultService : ITestResultService
    {
        private readonly IUnitOfWork dataStorage;
        private readonly IMapper mapper;

        public TestResultService(IUnitOfWork dataStorage, IMapper mapper)
        {
            this.dataStorage = dataStorage;
            this.mapper = mapper;
        }

        public async Task<Result<int>> AddResult(string userId, TestResultCreateDto testResultCreateDto)
        {
            var test = await dataStorage.Tests.GetAsync(testResultCreateDto.TestId);

            if (userId is null)
            {
                return Result.Fail<int>(-42);
            }
            if (test is null)
            {
                return Result.Fail<int>(-1);
            }

            var answers = (await dataStorage.Answers.GetCorrectAnswersForTest(testResultCreateDto.TestId)).ToList();

            var correctAnswersNumber = answers.Join(testResultCreateDto.Answers,
                    correctAnswer => correctAnswer.QuestionId,
                    userAnswer => userAnswer.Key,
                    (correctAnswer, userAnswer) => correctAnswer.Id == userAnswer.Value)
                .Count(result => result);

            double usersTestResult = (correctAnswersNumber / (double)answers.Count)*100;

            var testResult = new TestResult
            {
                TestId = testResultCreateDto.TestId,
                Result = usersTestResult,
                UserId = userId,
                AttemptDate = DateTime.Today
            };
            dataStorage.TestResults.Add(testResult);
            await dataStorage.SaveChangesAsync();
            
            return Result.Ok(testResult.Id);
        }

        public async Task<IEnumerable<TestResultDto>> GetAllUserResults(string userId, int offset, int count)
        {
            var allUsersTestResults = await dataStorage.TestResults.GetAllUsersTestResults(userId, offset, count);
            return mapper.Map<IEnumerable<TestResultDto>>(allUsersTestResults);
        }

        public async Task<long> GetUserResultsCount(string userId)
        {
            return await dataStorage.TestResults.LongCountAsync(userId);
        }

        public async Task<Result<TestResultDto>> GetResult(string userId, int resultId)
        {
            var testResult = await dataStorage.TestResults.GetAsync(resultId);
            if (testResult is null)
            {
                return Result.Fail<TestResultDto>(-1);
            }

            if (string.IsNullOrEmpty(userId))
            {
                return Result.Fail<TestResultDto>(-3);
            }
            if (testResult.UserId != userId)
            {
                return Result.Fail<TestResultDto>(-2);
            }
            return Result.Ok(mapper.Map<TestResultDto>(testResult));
        }


    }
}
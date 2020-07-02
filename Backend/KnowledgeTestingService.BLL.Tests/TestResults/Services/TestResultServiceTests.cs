using AutoMapper;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.BLL.TestResults.Services;
using KnowledgeTestingService.DAL.Entities;
using KnowledgeTestingService.DAL.UnitOfWork;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.Tests.TestResults.Services
{
    [TestFixture()]
    public class TestResultServiceTests
    {
        private ITestResultService testResultService;
        private Mock<IMapper> mapperMock;
        private Mock<IUnitOfWork> unitOfWorksMock;

        [OneTimeSetUp()]
        public void CreateMapperMock()
        {
            mapperMock = new Mock<IMapper>();

            mapperMock
                .Setup(m =>
                    m.Map<TestResult, TestResultDto>(It.IsAny<TestResult>())
                )
                .Returns((TestResult tr) => new TestResultDto
                {
                    Id = tr.Id,
                    AttemptDate = (long) tr.AttemptDate.Subtract(new DateTime(1970, 1, 1))
                        .TotalMilliseconds,
                    Result = tr.Result,
                    TestTitle = tr.Test.Title
                });

            mapperMock
                .Setup(m =>
                    m.Map<IEnumerable<TestResult>, IEnumerable<TestResultDto>>(It.IsAny<IEnumerable<TestResult>>())
                )
                .Returns((IEnumerable<TestResult> tr) =>
                {
                    var result = new LinkedList<TestResultDto>();
                    foreach (var testResult in tr)
                    {
                        result.AddLast(new TestResultDto
                        {
                            Id = testResult.Id,
                            AttemptDate = (long) testResult.AttemptDate.Subtract(new DateTime(1970, 1, 1))
                                .TotalMilliseconds,
                            Result = testResult.Result,
                            TestTitle = testResult.Test.Title
                        });
                    }

                    return result;
                });
        }

        [SetUp()]
        public void SetUp()
        {
            unitOfWorksMock = new Mock<IUnitOfWork>();
            
            testResultService = new TestResultService(unitOfWorksMock.Object, mapperMock.Object);
        }

        [Test()]
        public async Task AddResultTest()
        {
            unitOfWorksMock
                .Setup(u => u.Tests.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new Test
                {
                    Id = id,
                    Questions = new List<Question>()
                });

            unitOfWorksMock
                .Setup(u => u.Answers.GetCorrectAnswersForTest(It.IsAny<int>()))
                .ReturnsAsync((int id) => new []
                {
                    new Answer
                    {
                        Id = 1,
                        QuestionId = 1,
                        IsCorrect = true
                    },
                    new Answer
                    {
                        Id = 5,
                        QuestionId = 2,
                        IsCorrect = true
                    }
                });

            var testResultCreateDto = new TestResultCreateDto
            {
                TestId = 1,
                UserId = "user_id",
                Answers = new []
                {
                    new KeyValuePair<int, int>(1, 1),
                    new KeyValuePair<int, int>(2, 5)
                }
            };

            double expectedResult = 100;
            unitOfWorksMock
                .Setup(u => u.TestResults.Add(It.IsAny<TestResult>()))
                .Callback((TestResult testResult) => Assert.AreEqual(expectedResult, testResult.Result, 0.001));

            var result = await testResultService.AddResult("user_id",  testResultCreateDto);
            Assert.IsTrue(result.Success);

            testResultCreateDto.Answers = new[]
            {
                new KeyValuePair<int, int>(1, 1),
                new KeyValuePair<int, int>(2, 2)
            };
            expectedResult = 50;
            result = await testResultService.AddResult("user_id",  testResultCreateDto);
            Assert.IsTrue(result.Success);

            testResultCreateDto.Answers = new KeyValuePair<int, int>[0];
            expectedResult = 0;
            result = await testResultService.AddResult("user_id",  testResultCreateDto);
            Assert.IsTrue(result.Success);
        }

        [Test()]
        public async Task GetResultTest()
        {
            unitOfWorksMock
                .Setup(u => u.TestResults.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new TestResult
                {
                    Id = id,
                    AttemptDate = DateTime.Today,
                    Result = 100,
                    TestId = 0,
                    UserId = "user_id"
                });

            var result = await testResultService.GetResult("user_id", 0);
            Assert.IsTrue(result.Success);
        }

        [Test()]
        public async Task GetResultFailsTest()
        {
            unitOfWorksMock
                .Setup(u => u.TestResults.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => new TestResult
                {
                    Id = id,
                    AttemptDate = DateTime.Today,
                    Result = 100,
                    TestId = 0,
                    UserId = "user_id"
                });

            var result = await testResultService.GetResult("", 0);
            Assert.IsFalse(result.Success);
            
            result = await testResultService.GetResult("user", 0);
            Assert.IsFalse(result.Success);
        }

        [Test()]
        public async Task GetResultNullTest()
        {
            unitOfWorksMock
                .Setup(u => u.TestResults.GetAsync(It.IsAny<int>()))
                .ReturnsAsync((int id) => null);

            var result = await testResultService.GetResult("user_id", 0);
            Assert.IsFalse(result.Success);
        }

        [Test()]
        public async Task GetTestsGeneralStatisticTest()
        {
            unitOfWorksMock
                .Setup(u => u.Tests.GetRange(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<Test>());

            unitOfWorksMock
                .Setup(u => u.TestResults.GetAllByTestsRange(It.IsAny<IEnumerable<int>>()))
                .ReturnsAsync((IEnumerable<int> ids) => new List<TestResult>
                {
                    new TestResult
                    {
                        Id = 1,
                        TestId = 1,
                        Result = 100,

                        Test = new Test
                        {
                            Id = 1,
                            Title = "title_1"
                        }
                    },
                    new TestResult
                    {
                        Id = 2,
                        TestId = 1,
                        Result = 0,

                        Test = new Test
                        {
                            Id = 1,
                            Title = "title_1"
                        }
                    },
                    new TestResult
                    {
                        Id = 3,
                        TestId = 2,
                        Result = 100,

                        Test = new Test
                        {
                            Id = 2,
                            Title = "title_2"
                        }
                    },
                    new TestResult
                    {
                        Id = 5,
                        TestId = 3,
                        Result = 0,

                        Test = new Test
                        {
                            Id = 3,
                            Title = "title_3"
                        }
                    }
                });

            var result = (await testResultService.GetTestsGeneralStatistic(0, 5)).ToList();
            Assert.AreEqual(3, result.Count());
            using var enumerator = result.GetEnumerator();
            
            enumerator.MoveNext();

            Assert.AreEqual(2, enumerator.Current?.AttemptsNumber);
            Assert.AreEqual(50, enumerator.Current?.ResultsAverage, 0.001);
            enumerator.MoveNext();

            Assert.AreEqual(1, enumerator.Current?.AttemptsNumber);
            Assert.AreEqual(100, enumerator.Current?.ResultsAverage, 0.001);
            enumerator.MoveNext();

            Assert.AreEqual(1, enumerator.Current?.AttemptsNumber);
            Assert.AreEqual(0, enumerator.Current?.ResultsAverage, 0.001);
        }
    }
}
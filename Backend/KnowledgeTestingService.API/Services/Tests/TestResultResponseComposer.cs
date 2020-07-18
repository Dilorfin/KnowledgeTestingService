using AutoMapper;
using KnowledgeTestingService.API.Models.TestResult;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Tests
{
    public class TestResultResponseComposer : ITestResultResponseComposer
    {
        private readonly IMapper mapper;

        public TestResultResponseComposer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ComposeForCheckUserAnswers(Result<int> checkResult)
        {
            if (checkResult.Success)
            {
                return new OkObjectResult(checkResult.Value);
            }

            switch (checkResult.Status)
            {
                case -1:
                    return new BadRequestObjectResult("Such test doesn't seem to exist.");
                default:
                    return new BadRequestResult();
            }
        }

        public IActionResult ComposeForGetAllUsersResults(long userResultsCount, 
            IEnumerable<TestResultDto> testResultDtos)
        {
            return new OkObjectResult(new
            {
                ItemsCount = userResultsCount,
                ItemsModels =  mapper.Map<IEnumerable<TestResultModel>>(testResultDtos)
            });
        }

        public IActionResult ComposeForGetTestsGeneralStatistic(long testsGeneralStatisticCount, 
            IEnumerable<TestGeneralStatisticDto> testsGeneralStatistic)
        {
            return new OkObjectResult(new
            {
                ItemsCount = testsGeneralStatisticCount,
                ItemsModels =  mapper.Map<IEnumerable<TestGeneralStatisticModel>>(testsGeneralStatistic)
            });
        }

        public IActionResult ComposeForGetResult(Result<TestResultDto> result)
        {
            if (result.Success)
            {
                return new OkObjectResult(mapper.Map<TestResultModel>(result.Value));
            }

            return result.Status switch
            {
                -1 => new NotFoundResult(),
                -2 => new ForbidResult(),
                _ => new BadRequestResult()
            };
        }
    }
}
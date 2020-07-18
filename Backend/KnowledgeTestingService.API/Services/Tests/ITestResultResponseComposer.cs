using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Tests
{
    public interface ITestResultResponseComposer
    {
        IActionResult ComposeForCheckUserAnswers(Result<int> checkResult);
        IActionResult ComposeForGetAllUsersResults(long userResultsCount,
            IEnumerable<TestResultDto> testResultDtos);

        IActionResult ComposeForGetTestsGeneralStatistic(long testsGeneralStatisticCount,
            IEnumerable<TestGeneralStatisticDto> testsGeneralStatistic);

        IActionResult ComposeForGetResult(Result<TestResultDto> result);
    }
}
using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.TestResults.Services
{
    public interface ITestResultService
    {
        Task<Result<int>> AddResult(string userId, TestResultCreateDto testResultCreateDto);

        Task<Result<TestResultDto>> GetResult(string userId, int resultId);
        Task<IEnumerable<TestResultDto>> GetAllUserResults(string userId, int offset, int count);
        Task<long> GetUserResultsCount(string userId);

        Task<IEnumerable<TestGeneralStatisticDto>> GetTestsGeneralStatistic(int offset, int count);
        Task<long> GetTestsGeneralStatisticCount();
    }
}
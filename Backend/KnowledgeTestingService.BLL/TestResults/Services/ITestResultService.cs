using System.Collections.Generic;
using KnowledgeTestingService.Common;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.TestResults.Services
{
    public interface ITestResultService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="testResultCreateDto"></param>
        /// <returns>Id of result entity or error code</returns>
        Task<Result<int>> AddResult(string userId, TestResultCreateDto testResultCreateDto);

        Task<Result<TestResultDto>> GetResult(string userId, int resultId);
        Task<IEnumerable<TestResultDto>> GetAllUserResults(string userId, int offset, int count);
        Task<long> GetUserResultsCount(string userId);
    }
}
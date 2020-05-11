using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestService
    {
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo();
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo(int offset, int count);
        Task<Result<FullTestDto>> GetFullTest(int id);
        Task<Result<TestInfoDto>> GeTestInfo(int id);

        Task<long> GetTestsCount();
    }
}
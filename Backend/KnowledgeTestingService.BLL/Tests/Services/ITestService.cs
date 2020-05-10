using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestService
    {
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo();
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo(int offset, int count);
        Task<FullTestDto> GetFullTest(int id);
        Task<TestInfoDto> GeTestInfo(int id);

        Task<long> GetTestsCount();
    }
}
using KnowledgeTestingService.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestService
    {
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo(int offset, int count);
        Task<IEnumerable<TestInfoDto>> GeAllTestsInfo(int offset, int count, string filter);
        Task<Result<FullTestDto>> GetFullTest(int id);
        Task<Result<TestInfoDto>> GeTestInfo(int id);
        Task<Result<EditTestDto>> GetEditTest(int id);

        Task<Result> AddTest(EditTestDto editTestDto);
        Task<Result> UpdateTest(EditTestDto editTestDto);

        Task<long> GetTestsCount();
        Task<long> GetTestsCount(string filter);
    }
}
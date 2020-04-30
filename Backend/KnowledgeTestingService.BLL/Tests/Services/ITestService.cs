using System.Collections.Generic;

namespace KnowledgeTestingService.BLL.Tests.Services
{
    public interface ITestService
    {
        FullTestDto GetFullTest(int id);
        TestInfoDto GeTestInfo(int id);
        IEnumerable<TestInfoDto> GeAllTestsInfo();

        // TODO: check test results
    }
}
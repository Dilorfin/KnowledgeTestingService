using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestingService.API.Services.Tests
{
    public interface ITestPassingResponseComposer
    {
        IActionResult ComposeForCheckUserAnswers(Result<int> checkResult);
        IActionResult ComposeForGetFullTest(Result<FullTestDto> result);
    }
}
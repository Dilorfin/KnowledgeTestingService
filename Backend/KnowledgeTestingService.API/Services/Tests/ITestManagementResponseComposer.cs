using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestingService.API.Services.Tests
{
    public interface ITestManagementResponseComposer
    {
        IActionResult ComposeForGetEditTest(Result<EditTestDto> result);
        IActionResult ComposeAddTest(Result result);
        IActionResult ComposeUpdateTest(Result result);
    }
}
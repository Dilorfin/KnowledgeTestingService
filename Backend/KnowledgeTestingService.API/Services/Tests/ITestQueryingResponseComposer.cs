using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Tests
{
    public interface ITestQueryingResponseComposer
    {
        IActionResult ComposeForGetAllTestsInfo(long generalModelsCount, IEnumerable<TestInfoModel> testsInfoModels);
        IActionResult ComposeForGetTestInfo(Result<TestInfoDto> result);
    }
}
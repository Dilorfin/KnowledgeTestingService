using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeTestingService.API.Services.Tests
{
    public class TestPassingResponseComposer : ITestPassingResponseComposer
    {
        private readonly IMapper mapper;

        public TestPassingResponseComposer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ComposeForCheckUserAnswers(Result<int> checkResult)
        {
            if (checkResult.Success)
            {
                return new OkObjectResult(checkResult.Value);
            }

            switch (checkResult.Status)
            {
                case -1:
                    return new BadRequestObjectResult("Such test doesn't seem to exist.");
                default:
                    return new BadRequestResult();
            }
        }

        public IActionResult ComposeForGetFullTest(Result<FullTestDto> result)
        {
            if (result.Success)
            {
                return new OkObjectResult(mapper.Map<FullTestModel>(result.Value));
            }

            if (result.Status == -1)
            {
                return new BadRequestObjectResult("Such test doesn't seem to exist.");
            }

            return new BadRequestResult();
        }
    }
}
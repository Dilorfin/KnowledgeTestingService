using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Tests
{
    public class TestQueryingResponseComposer : ITestQueryingResponseComposer
    {
        private readonly IMapper mapper;

        public TestQueryingResponseComposer(IMapper mapper)
        {
            this.mapper = mapper;
        }

        public IActionResult ComposeForGetAllTestsInfo(long generalModelsCount,
            IEnumerable<TestInfoDto> testsInfoModels)
        {
            return new OkObjectResult(new
            {
                ItemsCount = generalModelsCount,
                ItemsModels =  mapper.Map<IEnumerable<TestInfoModel>>(testsInfoModels)
            });
        }

        public IActionResult ComposeForGetTestInfo(Result<TestInfoDto> result)
        {
            if (result.Success)
            {
                return new OkObjectResult(mapper.Map<TestInfoModel>(result.Value));
            }

            if (result.Status == -1)
            {
                return new BadRequestObjectResult("Such test doesn't seem to exist.");
            }

            return new BadRequestResult();
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
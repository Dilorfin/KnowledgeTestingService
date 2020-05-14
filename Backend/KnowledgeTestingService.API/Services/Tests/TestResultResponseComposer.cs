using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace KnowledgeTestingService.API.Services.Tests
{
    public class TestResultResponseComposer : ITestResultResponseComposer
    {
        private readonly IMapper mapper;

        public TestResultResponseComposer(IMapper mapper)
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

        public IActionResult ComposeForGetAllUsersResults(long userResultsCount, 
            IEnumerable<TestResultDto> testResultDtos)
        {
            return new OkObjectResult(new
            {
                ItemsCount = userResultsCount,
                ItemsModels =  mapper.Map<IEnumerable<TestResultModel>>(testResultDtos)
            });
        }
    }
}
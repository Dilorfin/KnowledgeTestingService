using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.API.Services.Tests;
using KnowledgeTestingService.BLL.Tests.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestQueryingController : ControllerBase
    {
        private readonly ITestService testService;
        private readonly IMapper mapper;
        private readonly ITestQueryingResponseComposer responseComposer;

        public TestQueryingController(ITestService testService, IMapper mapper,
            ITestQueryingResponseComposer responseComposer)
        {
            this.testService = testService;
            this.mapper = mapper;
            this.responseComposer = responseComposer;
        }

        [HttpGet("GetAllTestsInfo")]
        public async Task<IActionResult> GetAllTestsInfo(int offset, int count)
        {
            long testCount = await testService.GetTestsCount();

            var allTestsInfo = await testService.GeAllTestsInfo(offset, count);
            var testModels = mapper.Map<IEnumerable<TestInfoModel>>(allTestsInfo);
            
            return responseComposer.ComposeForGetAllTestsInfo(testCount, testModels);
        }

        [HttpGet("GetTestInfo/{id}")]
        public async Task<IActionResult> GetTestInfo(int id)
        {
            var result = await testService.GeTestInfo(id);
            return responseComposer.ComposeForGetTestInfo(result);;
        }
    }
}
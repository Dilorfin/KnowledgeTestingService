using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
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

        public TestQueryingController(ITestService testService, IMapper mapper)
        {
            this.testService = testService;
            this.mapper = mapper;
        }

        [HttpGet("GetAllTestsInfo")]
        public async Task<IActionResult> GetAllTestsInfo(int offset, int count)
        {
            long testCount = await testService.GetTestsCount();

            var allTestsInfo = await testService.GeAllTestsInfo(offset, count);
            var testModels = mapper.Map<IEnumerable<TestInfoModel>>(allTestsInfo);

            return Ok(new { ItemsCount = testCount, ItemsModels = testModels });
        }

        [HttpGet("GetTestInfo/{id}")]
        public async Task<IActionResult> GetAllTestsInfo(int id)
        {
            var allTestsInfo = await testService.GeTestInfo(id);
            var testInfoModel = mapper.Map<TestInfoModel>(allTestsInfo);
            return Ok(testInfoModel);
        }
    }
}
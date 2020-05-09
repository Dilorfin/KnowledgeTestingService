using AutoMapper;
using KnowledgeTestingService.BLL.Tests;
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
        public async Task<IActionResult> GetAllTestsInfo()
        {
            var allTestsInfo = await testService.GeAllTestsInfo();
            var testModels = mapper.Map<IEnumerable<TestInfoDto>>(allTestsInfo);
            return Ok(testModels);
        }
    }
}
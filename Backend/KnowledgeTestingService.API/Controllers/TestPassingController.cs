using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.BLL.TestResults.Services;
using KnowledgeTestingService.BLL.Tests.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestPassingController : Controller
    {
        private readonly ITestResultService testResultService;
        private readonly ITestService testService;
        private readonly IMapper mapper;

        public TestPassingController(ITestResultService testResultService, ITestService testService,
            IMapper mapper)
        {
            this.testResultService = testResultService;
            this.testService = testService;
            this.mapper = mapper;
        }

        [HttpGet("GetFullTest/{id}")]
        public async Task<IActionResult> GetFullTest(int id)
        {
            var fullTestDto = await testService.GetFullTest(id);
            var fullTestModel = mapper.Map<FullTestModel>(fullTestDto);
            return Ok(fullTestModel);
        }

        [HttpPost("CheckUserAnswers")]
        public async Task<IActionResult> CheckUserAnswers([FromBody] UserAnswersModel model)
        {
            if (model?.Answers is null)
                return BadRequest();

            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            var testResultCreateDto = mapper.Map<TestResultCreateDto>(model);
            var result = await testResultService.AddResult(userId, testResultCreateDto);
            return Ok(result);
        }
    }
}
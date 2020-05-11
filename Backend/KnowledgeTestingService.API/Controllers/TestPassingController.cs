using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.API.Services.Tests;
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
        private readonly ITestPassingResponseComposer responseComposer;

        public TestPassingController(ITestResultService testResultService, ITestService testService,
            IMapper mapper, ITestPassingResponseComposer responseComposer)
        {
            this.testResultService = testResultService;
            this.testService = testService;
            this.mapper = mapper;
            this.responseComposer = responseComposer;
        }

        [HttpGet("GetFullTest/{id}")]
        public async Task<IActionResult> GetFullTest(int id)
        {
            var result = await testService.GetFullTest(id);
            return responseComposer.ComposeForGetFullTest(result);
        }

        [HttpPost("CheckUserAnswers")]
        public async Task<IActionResult> CheckUserAnswers([FromBody] UserAnswersModel model)
        {
            if (model?.Answers is null)
                return BadRequest("Here is no answers");

            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var testResultCreateDto = mapper.Map<TestResultCreateDto>(model);
            
            var result = await testResultService.AddResult(userId, testResultCreateDto);
            return responseComposer.ComposeForCheckUserAnswers(result);
        }


        [HttpGet("GetResult/{id}")]
        public async Task<IActionResult> GetResult(int id)
        {
            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var result = await testResultService.GetResult(userId, id);
            if (result.Success)
            {
                return Ok(mapper.Map<TestResultModel>(result.Value));
            }

            return BadRequest();
        }
    }
}
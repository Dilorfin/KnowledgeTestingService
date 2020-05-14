using AutoMapper;
using KnowledgeTestingService.API.Models.Test;
using KnowledgeTestingService.API.Services.Tests;
using KnowledgeTestingService.BLL.TestResults;
using KnowledgeTestingService.BLL.TestResults.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TestResultController : Controller
    {
        private readonly ITestResultService testResultService;
        private readonly ITestResultResponseComposer responseComposer;
        private readonly IMapper mapper;

        public TestResultController(ITestResultService testResultService, ITestResultResponseComposer responseComposer,
            IMapper mapper)
        {
            this.testResultService = testResultService;
            this.responseComposer = responseComposer;
            this.mapper = mapper;
        }

        [HttpGet("GetAllUserResults")]
        public async Task<IActionResult> GetAllUserResults(int offset, int count)
        {
            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var userResultsCount = await testResultService.GetUserResultsCount(userId);
            var allUserResults = await testResultService.GetAllUserResults(userId, offset, count);
            return responseComposer.ComposeForGetAllUsersResults(userResultsCount, allUserResults);
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
    }
}
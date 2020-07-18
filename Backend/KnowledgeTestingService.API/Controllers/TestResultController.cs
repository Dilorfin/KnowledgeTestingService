using AutoMapper;
using KnowledgeTestingService.API.Models.TestResult;
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

        /// <summary>
        /// Get general statistic of each test in range.
        /// </summary>
        /// <param name="offset">Number of tests to skip</param>
        /// <param name="count">Number of tests to take</param>
        /// <returns>Returns general statistic of each test in range</returns>
        /// <response code="200">Always</response>
        [Authorize(Roles = "admin")]
        [HttpGet("GetTestsGeneralStatistic")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTestsGeneralStatistic(int offset, int count)
        {
            var generalStatisticCount = await testResultService.GetTestsGeneralStatisticCount();
            var testsGeneralStatistic = await testResultService.GetTestsGeneralStatistic(offset, count);
            return responseComposer.ComposeForGetTestsGeneralStatistic(generalStatisticCount, testsGeneralStatistic);
        }

        /// <summary>
        /// Get all user's results in range.
        /// </summary>
        /// <param name="offset">Number of results to skip</param>
        /// <param name="count">Number of results to take</param>
        /// <returns>Returns all user's results in range</returns>
        /// <response code="200">Always</response>
        [Authorize(Roles = "admin")]
        [HttpGet("GetAllUserResults")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllUserResults(int offset, int count)
        {
            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var userResultsCount = await testResultService.GetUserResultsCount(userId);
            var allUserResults = await testResultService.GetAllUserResults(userId, offset, count);
            return responseComposer.ComposeForGetAllUsersResults(userResultsCount, allUserResults);
        }

        /// <summary>
        /// Get result by id.
        /// </summary>
        /// <param name="id">Result id</param>
        /// <returns>Returns result by id</returns>
        /// <response code="200">If get succeeded</response>
        /// <response code="400">If id is incorrect</response>
        [HttpGet("GetResult/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(403)]
        [ProducesResponseType(404)]
        public async Task<IActionResult> GetResult(int id)
        {
            string userId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;

            var result = await testResultService.GetResult(userId, id);

            return responseComposer.ComposeForGetResult(result);
        }

        /// <summary>
        /// Checks user's answers.
        /// </summary>
        /// <param name="model">Answers to check</param>
        /// <returns>Returns result id</returns>
        /// <response code="200">If user's answers has been accepted</response>
        /// <response code="400">If model is incorrect</response>
        [HttpPost("CheckUserAnswers")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
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
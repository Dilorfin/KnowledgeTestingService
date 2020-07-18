using KnowledgeTestingService.API.Services.Tests;
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
        private readonly ITestQueryingResponseComposer responseComposer;

        public TestQueryingController(ITestService testService,
            ITestQueryingResponseComposer responseComposer)
        {
            this.testService = testService;
            this.responseComposer = responseComposer;
        }

        /// <summary>
        /// Get tests infos matching filter.
        /// </summary>
        /// <param name="offset">Number of tests to skip</param>
        /// <param name="count">Number of tests to take</param>
        /// <param name="filter">Filter to match</param>
        /// <returns>Returns tests infos matching filter</returns>
        /// <response code="200">Always</response>
        [HttpGet("GetAllTestsInfo")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllTestsInfo(int offset, int count, string filter)
        {
            long testsCount;
            IEnumerable<TestInfoDto> allTestsInfo;

            if (string.IsNullOrEmpty(filter))
            {
                testsCount = await testService.GetTestsCount();
                allTestsInfo = await testService.GetTestsInfoRange(offset, count);
            }
            else
            {
                testsCount = await testService.GetTestsCount(filter);
                allTestsInfo = await testService.GetTestsInfoRange(offset, count, filter);
            }

            return responseComposer.ComposeForGetAllTestsInfo(testsCount, allTestsInfo);
        }

        /// <summary>
        /// Get test info by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns test info by id</returns>
        /// <response code="200">If get succeeded</response>
        /// <response code="400">If test id is invalid</response>
        [HttpGet("GetTestInfo/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetTestInfo(int id)
        {
            var result = await testService.GeTestInfo(id);
            return responseComposer.ComposeForGetTestInfo(result);
        }

        /// <summary>
        /// Get full test by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns full test by id</returns>
        /// <response code="200">If get succeeded</response>
        /// <response code="400">If test id is invalid</response>
        [HttpGet("GetFullTest/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetFullTest(int id)
        {
            var result = await testService.GetFullTest(id);
            return responseComposer.ComposeForGetFullTest(result);
        }
    }
}
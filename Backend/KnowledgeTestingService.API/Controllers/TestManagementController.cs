using AutoMapper;
using KnowledgeTestingService.API.Models.TestManagement;
using KnowledgeTestingService.API.Services.Tests;
using KnowledgeTestingService.BLL.Tests;
using KnowledgeTestingService.BLL.Tests.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class TestManagementController : ControllerBase
    {
        private readonly ITestService testService;
        private readonly IMapper mapper;
        private readonly ITestManagementResponseComposer responseComposer;

        public TestManagementController(ITestService testService, IMapper mapper,
            ITestManagementResponseComposer responseComposer)
        {
            this.testService = testService;
            this.mapper = mapper;
            this.responseComposer = responseComposer;
        }
        
        /// <summary>
        /// Get test model for editing by id.
        /// </summary>
        /// <param name="id">Test id</param>
        /// <returns>Returns test model for editing by id</returns>
        /// <response code="200">If get succeeded</response>
        /// <response code="400">If test id is invalid</response>
        [HttpGet("GetEditTest/{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetEditTest(int id)
        {
            var result = await testService.GetEditTest(id);
            return responseComposer.ComposeForGetEditTest(result);
        }

        /// <summary>
        /// Creates new test.
        /// </summary>
        /// <param name="addTestModel">Test model to add</param>
        /// <returns>Error message if test model is invalid</returns>
        /// <response code="200">If add succeeded</response>
        /// <response code="400">If test is invalid</response>
        [HttpPost("AddTest")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> AddTest([FromBody] EditTestModel addTestModel)
        {
            var addTestDto = mapper.Map<AddTestDto>(addTestModel);
            var addResult = await testService.AddTest(addTestDto);

            return responseComposer.ComposeAddTest(addResult);
        }

        /// <summary>
        /// Updates test.
        /// </summary>
        /// <param name="editTestModel"></param>
        /// <returns>Error message if test model is invalid</returns>
        /// <response code="200">If update succeeded</response>
        /// <response code="400">If test is invalid</response>
        [HttpPost("UpdateTest")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> UpdateTest([FromBody] EditTestModel editTestModel)
        {
            var editTestDto = mapper.Map<EditTestDto>(editTestModel);
            var updateResult = await testService.UpdateTest(editTestDto);

            return responseComposer.ComposeUpdateTest(updateResult);
        }
    }
}
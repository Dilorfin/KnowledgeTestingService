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
        
        [HttpGet("GetEditTest/{id}")]
        public async Task<IActionResult> GetEditTest(int id)
        {
            var result = await testService.GetEditTest(id);
            return responseComposer.ComposeForGetEditTest(result);
        }

        [HttpPost("AddTest")]
        public async Task<IActionResult> AddTest([FromBody] EditTestModel editTestModel)
        {
            var editTestDto = mapper.Map<EditTestDto>(editTestModel);
            var addResult = await testService.AddTest(editTestDto);

            if (addResult.Success)
                return Ok();
            return BadRequest("smth went wrong");
        }

        
        [HttpPost("UpdateTest")]
        public async Task<IActionResult> UpdateTest([FromBody] EditTestModel editTestModel)
        {
            var editTestDto = mapper.Map<EditTestDto>(editTestModel);
            var updateResult = await testService.UpdateTest(editTestDto);
            if (updateResult.Success)
                return Ok();
            return BadRequest("ERRRROR!....");
        }
    }
}
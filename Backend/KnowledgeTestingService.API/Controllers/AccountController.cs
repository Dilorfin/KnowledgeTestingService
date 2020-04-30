using AutoMapper;
using KnowledgeTestingService.API.Models.Account;
using KnowledgeTestingService.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService accountService;
        private readonly IMapper mapper;

        public AccountController(IAccountService accountService, IMapper mapper)
        {
            this.accountService = accountService;
            this.mapper = mapper;

        }

        [Authorize(Roles = "admin")]
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllUsers(int offset, int count)
        {
            long usersCount = await accountService.GetUsersCount();

            var userDtos = await accountService.GetAll(offset, count);
            var userModels = mapper.Map<IEnumerable<UserModel>>(userDtos);

            return Ok(new { usersCount, userModels });
        }

        /// <summary>
        /// Performs user adding admin role.
        /// </summary>
        /// <param name="model">User set admin model</param>
        /// <response code="200">If adding admin role succeeded</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPost("SetAdmin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SetAdmin([FromBody]UserIdModel model)
        {
            if (model is null || string.IsNullOrEmpty(model.Id))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.SetAdmin(model.Id);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }

            return Ok();
        }

        /// <summary>
        /// Performs user adding admin role.
        /// </summary>
        /// <param name="model">User set admin model</param>
        /// <response code="200">If removing admin role succeeded</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [Authorize(Roles = "admin")]
        [HttpPost("RemoveAdmin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveAdmin([FromBody]UserIdModel model)
        {
            if (model is null || string.IsNullOrEmpty(model.Id))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.RemoveAdmin(model.Id);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }

            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Ban")]
        public async Task<IActionResult> BanUser([FromBody]UserIdModel model)
        {
            if (model is null || string.IsNullOrEmpty(model.Id))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.BanUser(model.Id);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }
            return Ok();
        }

        [Authorize(Roles = "admin")]
        [HttpPost("Unban")]
        public async Task<IActionResult> UnbanUser([FromBody]UserIdModel model)
        {
            if (model is null || string.IsNullOrEmpty(model.Id))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.UnbanUser(model.Id);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }
            return Ok();
        }
    }
}
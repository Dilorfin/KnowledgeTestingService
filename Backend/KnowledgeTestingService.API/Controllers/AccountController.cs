using AutoMapper;
using KnowledgeTestingService.API.Models.Account;
using KnowledgeTestingService.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        /// <summary>
        /// Get current user.
        /// </summary>
        /// <returns>Returns current user</returns>
        /// <response code="200">If get succeeded</response>
        /// <response code="400">If user id is invalid</response>
        [HttpGet("GetCurrentUser")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> GetCurrentUser()
        {
            string currentUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            var getUserResult = await accountService.GetUserById(currentUserId);

            if (getUserResult.Success)
            {
                var userModel = mapper.Map<UserModel>(getUserResult.Value);

                return Ok(userModel);
            }

            if (getUserResult.Status == -1)
            {
                return BadRequest("Unknown user");
            }

            return BadRequest();
        }

        /// <summary>
        /// Get all users in range.
        /// </summary>
        /// <param name="offset">Number of users to skip</param>
        /// <param name="count">Number of users to take</param>
        /// <returns>Returns all users in range</returns>
        /// <response code="200">Always</response>
        [Authorize(Roles = "admin")]
        [HttpGet("GetAllUsers")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetAllUsers(int offset, int count)
        {
            long usersCount = await accountService.GetUsersCount();

            var userDtos = await accountService.GetAll(offset, count);
            var userModels = mapper.Map<IEnumerable<UserModel>>(userDtos);

            return Ok(new { ItemsCount = usersCount, ItemsModels = userModels });
        }

        /// <summary>
        /// Performs adding admin role to user.
        /// </summary>
        /// <param name="userId">Id of user to add admin</param>
        /// <response code="200">If adding admin role succeeded</response>
        /// <response code="400">If the user id is invalid</response>
        [Authorize(Roles = "admin")]
        [HttpPost("SetAdmin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> SetAdmin(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.SetAdmin(userId);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }

            return Ok();
        }

        /// <summary>
        /// Performs removing admin role from user.
        /// </summary>
        /// <param name="userId">Id of user to remove admin</param>
        /// <response code="200">If removing admin role succeeded</response>
        /// <response code="400">If the user id is invalid</response>
        [Authorize(Roles = "admin")]
        [HttpPost("RemoveAdmin")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> RemoveAdmin(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }

            var identityErrors = await accountService.RemoveAdmin(userId);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }

            return Ok();
        }

        /// <summary>
        /// Performs user banning.
        /// </summary>
        /// <param name="userId">Id of user to ban</param>
        /// <response code="200">If banning succeeded</response>
        /// <response code="400">If the user id is invalid</response>
        [Authorize(Roles = "admin")]
        [HttpPost("Ban")]
        public async Task<IActionResult> BanUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            string currentUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (userId == currentUserId)
            {
                return BadRequest("You cannot ban yourself");
            }

            var identityErrors = await accountService.BanUser(userId);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }
            return Ok();
        }

        /// <summary>
        /// Performs user unbanning.
        /// </summary>
        /// <param name="userId">Id of user to unban</param>
        /// <response code="200">If unbanning succeeded</response>
        /// <response code="400">If the user id is invalid</response>
        [Authorize(Roles = "admin")]
        [HttpPost("Unban")]
        public async Task<IActionResult> UnbanUser(string userId)
        {
            if (string.IsNullOrEmpty(userId))
            {
                return BadRequest();
            }
            string currentUserId = HttpContext.User.FindFirst(ClaimTypes.Name)?.Value;
            if (userId == currentUserId)
            {
                return BadRequest("You cannot unban yourself");
            }
            var identityErrors = await accountService.UnbanUser(userId);
            if (identityErrors.Any())
            {
                return BadRequest(identityErrors);
            }
            return Ok();
        }
    }
}
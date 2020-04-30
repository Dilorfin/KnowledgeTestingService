using AutoMapper;
using KnowledgeTestingService.API.Models.Authentication;
using KnowledgeTestingService.API.Services.Authentication;
using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Authentication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace KnowledgeTestingService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationService authenticationService;
        private readonly IAuthenticationResponseComposer responseComposer;
        private readonly IMapper mapper;

        public AuthenticationController(IAuthenticationService authenticationService,
            IAuthenticationResponseComposer responseComposer,
            IMapper mapper)
        {
            this.authenticationService = authenticationService;
            this.responseComposer = responseComposer;
            this.mapper = mapper;
        }

        /// <summary>
        /// Performs user log in.
        /// </summary>
        /// <param name="model">User log in model</param>
        /// <response code="200">If the log in action succeeded</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [AllowAnonymous]
        [HttpPost("LogIn")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> LogIn([FromBody] UserLoginModel model)
        {
            if (model is null)
            {
                return BadRequest();
            }

            var userLogInDto = mapper.Map<UserLogInDto>(model);
            var logInResult = await authenticationService.LogIn(userLogInDto);
            return responseComposer.ComposeForLogIn(logInResult);
        }

        /// <summary>
        /// Performs user registration.
        /// </summary>
        /// <param name="model">User registration model</param>
        /// <response code="200">If the registration action succeeded</response>
        /// <response code="400">If the model is invalid or contains invalid data</response>
        [AllowAnonymous]
        [HttpPost("Register")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Register([FromBody] UserRegisterModel model)
        {
            if (model is null
                || string.IsNullOrEmpty(model.UserName)
                || string.IsNullOrEmpty(model.Password))
            {
                return BadRequest();
            }

            var userRegisterDto = mapper.Map<UserRegisterDto>(model);
            var identityErrors =
                await authenticationService.Register(userRegisterDto);

            return responseComposer.ComposeForRegister(identityErrors);
        }
    }
}
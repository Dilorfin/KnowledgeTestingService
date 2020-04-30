using KnowledgeTestingService.Authentication.DataTransferObjects;
using KnowledgeTestingService.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace KnowledgeTestingService.API.Services.Authentication
{
    public class AuthenticationResponseComposer : IAuthenticationResponseComposer
    {
        public IActionResult ComposeForLogIn(Result<TokenDto> logInResult)
        {
            if (logInResult.Success)
            {
                return new OkObjectResult(logInResult.Value);
            }

            if (logInResult.Status == -1)
            {
                return new BadRequestObjectResult("Invalid username.");
            }
            if (logInResult.Status == -2)
            {
                return new BadRequestObjectResult("User has been locked out.");
            }
            if (logInResult.Status == -3)
            {
                return new BadRequestObjectResult("Invalid password.");
            }
            return new BadRequestResult();
        }

        public IActionResult ComposeForRegister(IEnumerable<IdentityError> registrationResult)
        {
            if (registrationResult.Any())
            {
                return new BadRequestObjectResult(registrationResult);
            }
            return new OkResult();
        }
    }
}